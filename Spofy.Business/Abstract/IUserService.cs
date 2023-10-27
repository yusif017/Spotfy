using Spotfy.Core.Utilities.Results.Abstract;
using Spotfy.Entities.DTOs.UserDTOs;

namespace Spotfy.Business.Abstract
{
    public interface IUserService
    {
        IResult Login(UserLoginDTO userLoginDTO);
        IResult Register(UserRegisterDTO userRegisterDTO);
        IResult VerifyEmail(string email, string verifyToken);
    }
}
