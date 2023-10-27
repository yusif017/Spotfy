using Spotfy.Entities.Concreate;
using Spotfy.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotfy.Entities.Concrete
{
    public class Music : IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string PhotoUrl { get; set; }
        public string MusicUrl { get; set; }
        public int Vievcount { get; set; }
        public DateTime MusicTime { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
