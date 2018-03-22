using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PermGuide.Classes
{
    class Timetable : BaseDatabaseObject
    {
        internal Timetable(DatabaseManager man, TimetableRecord timetableRecord) :
            base(man)
        {
            TimetableRecord = timetableRecord;
        }

        internal TimetableRecord TimetableRecord { get; private set; }
    }
}
