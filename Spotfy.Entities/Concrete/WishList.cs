using Spotfy.Core.Entities.Abstract;
using Spotfy.Entities.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotfy.Entities.Concrete
{
    public class WishList: IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public  Music Music { get; set; }
        public int MusicId { get; set; }

    }
}
