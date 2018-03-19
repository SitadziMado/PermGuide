using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PermGuide.Classes
{
    class Sight : IContent
    {
        internal Sight(SightRecord sightRecord)
        {
            SightRecord = sightRecord;
        }

        public ContentRecord GetRecord()
        {
            return SightRecord;
        }

        public DbGeography Location => SightRecord.Location;

        internal SightRecord SightRecord { get; private set; }
    }
}
