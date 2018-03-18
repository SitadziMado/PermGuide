using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PermGuide.Classes
{
    class User
    {
        private User(UserRecord userRecord)
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

            try
            {
                return new User(ans.Single());
            }
            catch (InvalidOperationException)
            {
                throw new UserNotRegisteredException();
            }
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

        public static readonly User Empty = 
            new User(new UserRecord { Login = "undefined", Password = "undefined" });

        public bool Valid => DatabaseManager.Container.UserRecordSet.Contains(mUserRecord);

        private UserRecord mUserRecord;
    }
}
