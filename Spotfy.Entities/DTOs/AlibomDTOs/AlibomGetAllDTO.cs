using Spotfy.Entities.Concreate;
using Spotfy.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotfy.Entities.DTOs.AlibomDTOs
{
    public class AlibomGetAllDTO
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public int userId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Description { get; set; }
        public string PhotoUrl { get; set; }
        public List<AlbomItemsDto> AlbomItems { get; set; }
    }
    public class AlbomItemsDto
    {
        public int MusicId { get; set; }

        public string Name { get; set; }
        public string PhotoUrl { get; set; }
        public string MusicUrl { get; set; }


    }

}
