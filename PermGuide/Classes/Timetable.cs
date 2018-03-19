using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PermGuide.Classes
{
    class Timetable
    {
        internal Timetable(TimetableRecord timetableRecord)
        {
            TimetableRecord = timetableRecord;
        }

        internal TimetableRecord TimetableRecord { get; private set; }
    }
}
