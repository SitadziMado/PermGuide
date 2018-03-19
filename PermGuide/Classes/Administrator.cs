using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PermGuide.Classes
{
    class Administrator : User
    {
        public Administrator(UserRecord userRecord) :
            base(userRecord)
        {

        }

        /* Administrator
         ***************
         * ChangeStatus(User)
         * Ban(User)
         * GetComplaints()
         */
    }
}
