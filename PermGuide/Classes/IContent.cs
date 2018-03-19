using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PermGuide.Classes
{
    interface IContent
    {
        // void Process(ProposalStatus status);
        ContentRecord GetRecord();
    }
}
