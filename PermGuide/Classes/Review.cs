using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PermGuide.Classes
{
    class Review
    {
        internal Review(ReviewRecord reviewRecord)
        {
            ReviewRecord = reviewRecord;
        }

        internal ReviewRecord ReviewRecord { get; private set; }
    }
}
