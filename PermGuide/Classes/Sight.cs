using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PermGuide.Classes
{
    class Sight : BaseContent
    {
        internal Sight(SightRecord sightRecord) :
            base(sightRecord)
        {

        }

        public DbGeography Location => (Record as SightRecord).Location;

        internal SightRecord SightRecord => Record as SightRecord;
    }
}
