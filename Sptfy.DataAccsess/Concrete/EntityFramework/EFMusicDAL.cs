using Spotfy.Entities.Concrete;
using Spotfy.Core.DataAccess.EntitFramework;
using Spotfy.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpotfyDataAccess.Concrete.EntityFramework;

namespace Spotfy.DataAccess.Concrete.EntityFramework
{
    public class EFMusicDAL : EFRepositoryBase<Music, AppDbContext>, IMusicDAL
    {
    }
}
