
using Spotfy.Entities.Concreate;
using Spotfy.Core.DataAccess.EntitFramework;
using Spotfy.DataAccess.Abstract;

namespace SpotfyDataAccess.Concrete.EntityFramework
{
    public class EFUserDAL : EFRepositoryBase<User, AppDbContext>, IUserDAL
    {
       
    }
}
