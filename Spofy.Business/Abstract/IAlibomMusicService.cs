using Entities.DTOs.WishListDTO;
using Spotfy.Core.Utilities.Results.Abstract;
using Spotfy.Entities.DTOs.AlibomMusicDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spofy.Business.Abstract
{
    public interface IAlibomMusicService
    {
        IResult AddAlibomList(int AlibomId, AlibomMusicListAddDto addDto);
        IDataResult<List<AlibomListItemDTO>> GetUserAlibomList(int userId);
        IDataResult<List<AlibomListItemDTO>> GetAllAlibomList();

    }
}
