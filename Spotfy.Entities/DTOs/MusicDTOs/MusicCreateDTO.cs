using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotfy.Entities.DTOs.MusicDTOs
{
    public class MusicCreateDTO
    {
        public string Title { get; set; }
        public string MusicUrl { get; set; }
        public string PhotoUrl { get; set; }
    }
}
