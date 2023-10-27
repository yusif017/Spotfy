using Entities.DTOs.WishListDTO;
using Spotfy.Core.Utilities.Results.Abstract;
using Spotfy.Entities.DTOs.WishListDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spofy.Business.Abstract
{
    public interface IWishListService
    {
        IResult AddWishList(int userId, WishListAddItemDTO wishListAddItemDTO);
        IDataResult<List<WishListItemDTO>> GetUserWishList(int userId);
    }
}
