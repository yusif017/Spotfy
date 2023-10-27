using Spotfy.Core.DataAccess;
using Spotfy.Entities.Concrete;
using Spotfy.Entities.DTOs.AlibomMusicDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sptfy.DataAccsess.Abstract
{
    public interface IAlibomMusicDAL: IRepositoryBase<AlibomMusic>
    {
        List<AlibomListItemDTO> GetAlibomList(int userId);
        List<AlibomListItemDTO> GetAllAlibomList();

    }
}
