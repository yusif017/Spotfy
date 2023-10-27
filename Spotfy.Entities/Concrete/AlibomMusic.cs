using Spotfy.Core.Entities.Abstract;
using Spotfy.Entities.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotfy.Entities.Concrete
{
    public class AlibomMusic :IEntity
    {
        public int Id { get; set; }
        public int AlibomId { get; set; }
        public Alibom Alibom { get; set; }
        public int MusicId { get; set; }
        public Music Music { get; set; }


    }
}
