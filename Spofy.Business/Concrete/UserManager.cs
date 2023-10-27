﻿

using AutoMapper;
using MassTransit;
using Spotfy.Entities.Concreate;
using Spotfy.Business.Abstract;
using Spotfy.Core.Utilities.Business;
using Spotfy.Core.Utilities.Results.Abstract;
using Spotfy.Core.Utilities.Results.Concrete.ErrorResults;
using Spotfy.Core.Utilities.Results.Concrete.SuccessResults;
using Spotfy.Core.Utilities.Security.Hashing;
using Spotfy.Core.Utilities.Security.JWT;
using Spotfy.DataAccess.Abstract;
using Spotfy.Entities.DTOs.UserDTOs;
using Spotfy.Entities.ShareModels;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserDAL _userDAL;
        private readonly IMapper _mapper;
        private readonly IPublishEndpoint _publishEndpoint;
        public UserManager(IUserDAL userDAL, IMapper mapper, IPublishEndpoint publishEndpoint)
        {
            _userDAL = userDAL;
            _mapper = mapper;
            _publishEndpoint = publishEndpoint;
        }

        public IResult Login(UserLoginDTO userLoginDTO)
        {
            var result = BusinessRules.Check(CheckUserConfirmedEmail(userLoginDTO.Email),
                CheckUserPasswordVerify(userLoginDTO.Email, userLoginDTO.Password),
                CheckUserLoginAttempt(userLoginDTO.Email));
            
            var user = _userDAL.Get(x => x.Email == userLoginDTO.Email);

            if (!result.Success)
            {
                return new ErrorResult("Email is not Confirmed!");
            }

            if (CheckUserExist(userLoginDTO.Email).Success)
            {
                user.LoginAttempt += 1;
                return new ErrorResult("User does not exist");
            }

            user.LoginAttempt = 0;

            var token = Token.TokenGenerator(user, "User");

            return new SuccessResult(token);
        }

        public IResult Register(UserRegisterDTO userRegisterDTO)
        {
            var result = BusinessRules.Check(CheckUserExist(userRegisterDTO.Email));

            if (!result.Success)
                return new ErrorResult("Email exists");

            var map = _mapper.Map<User>(userRegisterDTO);
            
            HashingHelper.HashPassword(userRegisterDTO.Password, out byte[] passwordHash, out byte[] passwordSalt);
            
            map.PasswordSalt = passwordSalt;
            map.PasswordHash = passwordHash;

            map.Token = Guid.NewGuid().ToString();
            map.TokenExpiresDate = DateTime.Now.AddMinutes(10);

            _userDAL.Add(map);

            SendEmailCommand sendEmailCommand = new()
            {
                Lastname = map.LastName,
                Firstname = map.FirstName,
                Token = map.Token,
                Email = map.Email
            };
            _publishEndpoint.Publish<SendEmailCommand>(sendEmailCommand);
            return new SuccessResult("User Registered Successfully!");
        }

        public IResult VerifyEmail(string email, string verifyToken)
        {
            var user = _userDAL.Get(x => x.Email == email);

            if (user == null) return new ErrorResult("User does not exits");

            if (user.Token == verifyToken)
            {
                if (DateTime.Compare(user.TokenExpiresDate, DateTime.Now) < 0)
                {
                    return new ErrorResult("Token expires");
                }
                user.EmailConfirmed = true;
                _userDAL.Update(user);
                return new SuccessResult();
            }
            return new ErrorResult();
        }

        private IResult CheckUserConfirmedEmail(string email)
        {
            var user = _userDAL.Get(x => x.Email == email);

            if (!user.EmailConfirmed)
            {
                user.TokenExpiresDate = DateTime.Now.AddMinutes(10);
                SendEmailCommand sendEmailCommand = new()
                {
                    Lastname = user.LastName,
                    Firstname = user.FirstName,
                    Token = user.Token,
                    Email = user.Email
                };
                _publishEndpoint.Publish<SendEmailCommand>(sendEmailCommand);
            }

            return new SuccessResult();
        }
        private IResult CheckUserExist(string email)
        {
            var user = _userDAL.Get(x => x.Email == email);

            if (user != null)
                return new ErrorResult();

            return new SuccessResult();
        }
        private IResult CheckUserPasswordVerify(string email, string password)
        {
            var user = _userDAL.Get(x => x.Email == email);

            var result = HashingHelper.VerifyPassword(password, user.PasswordHash, user.PasswordSalt);

            if (!result)
                return new ErrorResult("Email or Password wrong!");

            return new SuccessResult();
        }
        private IResult CheckUserLoginAttempt(string email)
        {
            var user = _userDAL.Get(x => x.Email == email);

            if (user.LoginAttempt > 3)
            {
                if (user.LoginAttemptExpires == null)
                {
                    user.LoginAttemptExpires = DateTime.Now.AddMinutes(10);
                }
                return new ErrorResult("Login Attempt more than 3 please wait 10 minute");
            }

            if(DateTime.Compare(user.LoginAttemptExpires, DateTime.Now) < 0)
            {
                return new SuccessResult();
            }
            return new SuccessResult();
        }
    }
}
