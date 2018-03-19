using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PermGuide.Classes
{
    class Excursion : IContent, IProposable
    {
        internal Excursion(ExcursionRecord excursionRecord)
        {
            ExcursionRecord = excursionRecord;
        }

        public ExcursionRecord ExcursionRecord { get; private set; }
    }
}
