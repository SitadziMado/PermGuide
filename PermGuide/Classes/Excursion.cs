using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PermGuide.Classes
{
    class Excursion : IContent
    {
        internal Excursion(ExcursionRecord excursionRecord)
        {
            ExcursionRecord = excursionRecord;
        }

        public ContentRecord GetRecord()
        {
            return ExcursionRecord;
        }

        public IEnumerable<DbGeography> Points 
            => from v in ExcursionRecord.SightRecord select v.Location;

        internal ExcursionRecord ExcursionRecord { get; private set; }
    }
}
