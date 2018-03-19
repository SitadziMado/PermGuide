using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PermGuide.Classes
{
    class File
    {
        internal File(FileRecord fileRecord)
        {
            FileRecord = fileRecord;
        }

        public FileRecord FileRecord { get; private set; }
    }
}
