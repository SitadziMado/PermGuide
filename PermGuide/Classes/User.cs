using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PermGuide.Classes
{
    class User
    {
        protected User(UserRecord userRecord)
        {
            mUserRecord = userRecord;
        }

        public static User Register(string login, string password, string nickname = "")
        {
            var userRecord = new UserRecord
            {
                Login = login,
                Password = password.Encrypt(),
                Nickname = nickname,
                Status = UserStatusString
            };

            var ans = from v
                      in DatabaseManager.Container.UserRecordSet
                      where v.Login == login
                      select v;

            if (ans.Count() == 0)
                throw new UserNotRegisteredException();

            DatabaseManager.Container.UserRecordSet.Add(userRecord);
            DatabaseManager.Container.SaveChanges();

            return new User(userRecord);
        }

        public static User Login(string login, string password)
        {
            var encryptedPassword = password.Encrypt();

            var ans = from v
                      in DatabaseManager.Container.UserRecordSet
                      where v.Login == login && v.Password == encryptedPassword
                      select v;

            User result;

            try
            {
                var rec = ans.Single();

                switch (rec.Status)
                {
                    case UserStatusString: result = new User(rec); break;
                    case ModeratorStatusString: result = new Moderator(rec); break;
                    case AdministratorStatusString: result = new Administrator(rec); break;
                    default: throw new UserNotRegisteredException();
                }
            }
            catch (InvalidOperationException)
            {
                throw new UserNotRegisteredException();
            }

            return result;
        }

        public void UpdateData(string login, string password, string nickname)
        {
            if (!Valid)
                throw new RecordNotValidException();

            mUserRecord.Login = login;
            mUserRecord.Password = password.Encrypt();
            mUserRecord.Nickname = nickname;

            DatabaseManager.Container.SaveChanges();
        }

        /* User
         ******
         * GetSightPoints()
         * LeaveReview(IReviewable) where IReviewable = { Sight, Excursion }
         * GetExcursionsInfo()
         * Propose(IProposable) where IProposable = { Sight, Excursion, Article }
         * GetArticleInfo()
         * UploadMedia(File)
         * GetTimetableInfo()
         */

        public static readonly User Empty = 
            new User(new UserRecord { Login = "undefined", Password = "undefined" });

        public bool Valid => DatabaseManager.Container.UserRecordSet.Contains(mUserRecord);

        private const string UserStatusString = "user";
        private const string ModeratorStatusString = "moderator";
        private const string AdministratorStatusString = "administrator";

        private UserRecord mUserRecord;
    }
}
