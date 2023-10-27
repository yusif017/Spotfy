using Spotfy.Core.Utilities.Results.Abstract;
using Spotfy.Entities.DTOs.MusicDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotfy.Business.Abstract
{
    public interface IMusicService
    {
        IResult AddMusic(int userId, MusicCreateDTO musicCreateDTO);
    }
}
