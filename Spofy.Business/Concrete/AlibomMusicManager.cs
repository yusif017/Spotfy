using AutoMapper;
using Entities.DTOs.WishListDTO;
using Spofy.Business.Abstract;
using Spotfy.Core.Utilities.Results.Abstract;
using Spotfy.Core.Utilities.Results.Concrete.ErrorResults;
using Spotfy.Core.Utilities.Results.Concrete.SuccessResults;
using Spotfy.Entities.Concreate;
using Spotfy.Entities.Concrete;
using Spotfy.Entities.DTOs.AlibomMusicDtos;
using Sptfy.DataAccsess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spofy.Business.Concrete
{
    public class AlibomMusicManager : IAlibomMusicService
    {
        private readonly IAlibomMusicDAL _alibomDal;
        private readonly IMapper _mapper;

        public AlibomMusicManager(IAlibomMusicDAL alibomDal, IMapper mapper)
        {
            _alibomDal = alibomDal;
            _mapper = mapper;
        }

        public IResult AddAlibomList(int AlibomId, AlibomMusicListAddDto addDto)
        {
            var map = _mapper.Map<AlibomMusic>(addDto);
            map.AlibomId = AlibomId;
            _alibomDal.Add(map);
            return new SuccessResult();
        }

        public IDataResult<List<AlibomListItemDTO>> GetUserAlibomList(int userId)
        {
            var useralibomList = _alibomDal.GetAlibomList(userId);

            if (!useralibomList.Any())
                return new ErrorDataResult<List<AlibomListItemDTO>>("Error");

            return new SuccessDataResult<List<AlibomListItemDTO>>(useralibomList);
        }
        public IDataResult<List<AlibomListItemDTO>> GetAllAlibomList()
        {
            var useralibomList = _alibomDal.GetAllAlibomList();

            if (!useralibomList.Any())
                return new ErrorDataResult<List<AlibomListItemDTO>>("Error");

            return new SuccessDataResult<List<AlibomListItemDTO>>(useralibomList);
        }

    }
}

