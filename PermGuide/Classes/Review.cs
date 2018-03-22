using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PermGuide.Classes
{
    class Review : BaseDatabaseObject
    {
        internal Review(DatabaseManager man, ReviewRecord reviewRecord) :
            base(man)
        {
            ReviewRecord = reviewRecord;
        }

        internal ReviewRecord ReviewRecord { get; private set; }
    }
}
