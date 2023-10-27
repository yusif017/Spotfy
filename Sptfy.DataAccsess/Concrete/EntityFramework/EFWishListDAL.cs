using DataAccess.Abstract;
using Microsoft.EntityFrameworkCore;
using Spotfy.Core.DataAccess.EntitFramework;
using Spotfy.Entities.Concrete;
using SpotfyDataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EFWishListDAL : EFRepositoryBase<WishList, AppDbContext>, IWishListDAL
    {
        public List<WishList> GetUserWishList(int userId)
        {
            using var context = new AppDbContext();
            var result = context.WishLists.Include(x => x.Music).Where(x => x.UserId == userId).ToList();
            return result;
        }
    }
}
