using AutoMapper;
using Spotfy.Entities.Concrete;
using Spotfy.Business.Abstract;
using Spotfy.Core.Utilities.Results.Abstract;
using Spotfy.Core.Utilities.Results.Concrete.SuccessResults;
using Spotfy.DataAccess.Abstract;
using Spotfy.Entities.DTOs.MusicDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MassTransit.MessageHeaders;

namespace SpotfyBusiness.Concrete
{
    public class MusicManager : IMusicService
    {
        private readonly IMusicDAL _musicDAL;
        private readonly IMapper _mapper;

        public MusicManager(IMusicDAL musicDAL, IMapper mapper)
        {
            _musicDAL = musicDAL;
            _mapper = mapper;
        }

        public IResult AddMusic(int userId, MusicCreateDTO musicCreateDTO)
        {
            var mapper = _mapper.Map<Music>(musicCreateDTO);
            mapper.UserId = userId;
            mapper.CreatedDate = DateTime.Now;
            mapper.Status = true;
           
            _musicDAL.Add(mapper);
            return new SuccessResult();
        }
    }
}
