using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PermGuide.Classes
{
    class Sight : IContent, IProposable
    {
        internal Sight(SightRecord sightRecord)
        {
            SightRecord = sightRecord;
        }

        public SightRecord SightRecord { get; private set; }
    }
}
