using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PermGuide.Classes
{
    class Administrator : User
    {
        internal Administrator(UserRecord userRecord) :
            base(userRecord)
        {

        }

        public void ChangeStatus(User other, UserStatus status)
        {
            other.UserRecord.Status = status;
            Manager.Container.SaveChanges();
        }

        public void Ban(User other, DateTime tillWhen)
        {
            other.UserRecord.BanStatus.IsBanned = true;
            other.UserRecord.BanStatus.BannedTill = tillWhen;
            Manager.Container.SaveChanges();
        }

        public HashSet<Review> GetComplaints()
        {
            // ToDo: upgrade this method
            return GetHashSetOfRecords<Review, ReviewRecord>(x => x.Mark == "");
        }

        /* Administrator
         ***************
         V ChangeStatus(User)
         V Ban(User)
         V GetComplaints()
         */
    }
}
