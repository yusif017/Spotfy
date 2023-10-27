using Spotfy.Core.Entities.Abstract;
using Spotfy.Entities.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotfy.Entities.Concrete
{
    public class Alibom :IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PhotoUrl { get; set; }
        public int UserId { get; set; }
        public User User{ get; set; }
        public bool IsAcrive { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<AlibomMusic> AlibomMusics { get; set; }

    }
}
