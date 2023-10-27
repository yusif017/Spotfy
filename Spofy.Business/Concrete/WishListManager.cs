using AutoMapper;
using Spofy.Business.Abstract;
using DataAccess.Abstract;
using Entities.DTOs.WishListDTO;
using Spotfy.Core.Utilities.Results.Abstract;
using Spotfy.Core.Utilities.Results.Concrete.ErrorResults;
using Spotfy.Core.Utilities.Results.Concrete.SuccessResults;
using Spotfy.Entities.Concrete;
using Spotfy.Entities.DTOs.WishListDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotfy.Business.Concrete
{
    public class WishListManager : IWishListService
    {
        private readonly IWishListDAL _wishListDAL;
        private readonly IMapper _mapper;
        public WishListManager(IWishListDAL wishListDAL, IMapper mapper)
        {
            _wishListDAL = wishListDAL;
            _mapper = mapper;
        }

        public IResult AddWishList(int userId, WishListAddItemDTO wishListAddItemDTO)
        {
            var map = _mapper.Map<WishList>(wishListAddItemDTO);
            map.UserId = userId;
            _wishListDAL.Add(map);
            return new SuccessResult();
        }

        public IDataResult<List<WishListItemDTO>> GetUserWishList(int userId)
        {
            var userWishList = _wishListDAL.GetUserWishList(userId);

            if (!userWishList.Any())
                return new ErrorDataResult<List<WishListItemDTO>>();

            var map = _mapper.Map<List<WishListItemDTO>>(userWishList);

            return new SuccessDataResult<List<WishListItemDTO>>(map);
        }
    }
}
