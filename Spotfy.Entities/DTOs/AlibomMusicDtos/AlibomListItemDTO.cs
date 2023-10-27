using Spotfy.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotfy.Entities.DTOs.AlibomMusicDtos
{
    public class AlibomListItemDTO
    {
        public int AlibomId { get; set; }
        public bool IsAcrive { get; set; }

        public List<AlbomMusicItemsDto> Musics { get; set; }
    }

    public class AlbomMusicItemsDto
    {
        public int MusicId { get; set; }
        public string Name { get; set; }
        public string PhotoUrl { get; set; }
        public string MusicUrl { get; set; }

    }
}
