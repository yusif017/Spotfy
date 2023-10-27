using Spotfy.Core.DataAccess;
using Spotfy.Entities.Concrete;
using Spotfy.Entities.DTOs.AlibomDTOs;
using Spotfy.Entities.DTOs.AlibomMusicDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sptfy.DataAccsess.Abstract
{
    public interface IAlibomDAL: IRepositoryBase<Alibom>
    {


        List<AlibomGetAllDTO> GetByUserAlibomList();
        AlibomGetAllDTO GetByAlibomList(int id);

    }
}
