using AutoMapper;
using Entities.DTOs.WishListDTO;
using Spofy.Business.Abstract;
using Spotfy.Core.Utilities.Results.Abstract;
using Spotfy.Core.Utilities.Results.Concrete.ErrorResults;
using Spotfy.Core.Utilities.Results.Concrete.SuccessResults;
using Spotfy.Entities.Concrete;
using Spotfy.Entities.DTOs.AlibomDTOs;
using Spotfy.Entities.DTOs.AlibomMusicDtos;
using Spotfy.Entities.DTOs.MusicDTOs;
using Sptfy.DataAccsess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spofy.Business.Concrete
{
    public class AlibomManager : IAlibomService
    {
        private readonly IAlibomDAL _alibomDal;
        private readonly IMapper _mapper;

        public AlibomManager(IAlibomDAL alibomDal, IMapper mapper)
        {
            _alibomDal = alibomDal;
            _mapper = mapper;
        }
        public IResult AddAlibom(int userId, AlibomCreateDTO alibomCreateDTO)
        {
            var mapper = _mapper.Map<Alibom>(alibomCreateDTO);
            mapper.UserId = userId;
            mapper.CreatedDate = DateTime.Now;
            mapper.Status = true;
            mapper.IsAcrive = true;
            _alibomDal.Add(mapper);
            return new SuccessResult();
        }

        public IDataResult<List<AlibomGetAllDTO>> GetUserAllAlibomList()
        {

            
                var useralibomList = _alibomDal.GetByUserAlibomList();

                if (!useralibomList.Any())
                    return new ErrorDataResult<List<AlibomGetAllDTO>>("Error");

                return new SuccessDataResult<List<AlibomGetAllDTO>>(useralibomList);
            
        }
        public IDataResult<AlibomGetAllDTO> GetAlibom(int id)
        {


            var useralibomList = _alibomDal.GetByAlibomList(id);

            
            return new SuccessDataResult<AlibomGetAllDTO>(useralibomList);


        }
    }
}
