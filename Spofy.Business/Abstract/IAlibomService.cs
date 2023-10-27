using Entities.DTOs.WishListDTO;
using Spotfy.Core.Utilities.Results.Abstract;
using Spotfy.Entities.DTOs.AlibomDTOs;
using Spotfy.Entities.DTOs.AlibomMusicDtos;
using Spotfy.Entities.DTOs.MusicDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spofy.Business.Abstract
{
    public interface IAlibomService
    {
        IResult AddAlibom(int userId, AlibomCreateDTO alibomCreateDTO);
        IDataResult<List<AlibomGetAllDTO>> GetUserAllAlibomList();
        IDataResult<AlibomGetAllDTO> GetAlibom(int id);


    }
}
