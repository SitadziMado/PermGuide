using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PermGuide.Classes
{
    class DatabaseManager
    {
        public DatabaseManager()
        {
            Container = new PermGuideContainer();

            // При добавлении класса следует обновить
            mSets = new Dictionary<Type, object>
            {
                { typeof(ArticleRecord), Container.ArticleRecordSet },
                { typeof(ExcursionRecord), Container.ExcursionRecordSet },
                { typeof(FileRecord), Container.FileRecordSet },
                { typeof(RegionRecord), Container.RegionRecordSet },
                { typeof(ReviewRecord), Container.ReviewRecordSet },
                { typeof(SightRecord), Container.SightRecordSet },
                { typeof(TimetableRecord), Container.TimetableRecordSet },
                { typeof(UserRecord), Container.UserRecordSet },

                { typeof(DbSet<ArticleRecord>), Container.ArticleRecordSet },
                { typeof(DbSet<ExcursionRecord>), Container.ExcursionRecordSet },
                { typeof(DbSet<FileRecord>), Container.FileRecordSet },
                { typeof(DbSet<RegionRecord>), Container.RegionRecordSet },
                { typeof(DbSet<ReviewRecord>), Container.ReviewRecordSet },
                { typeof(DbSet<SightRecord>), Container.SightRecordSet },
                { typeof(DbSet<TimetableRecord>), Container.TimetableRecordSet },
                { typeof(DbSet<UserRecord>), Container.UserRecordSet },
            };
        }

        public bool Exists<T>(T item) where T : class
        {
            DbSet<T> set = GetRecordSet<T>();
            return set.Contains(item);
        }

        public DbSet<T> GetRecordSet<T>() where T : class
        {
            try
            {
                DbSet<T> t = (DbSet<T>)mSets[typeof(T)];
                return t;
            }
            catch (KeyNotFoundException)
            {
                Debug.WriteLine($"Класс {typeof(T).Name} еще не существует.");
                throw;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
                throw;
            }
        }

        public User Register(string login, string password, string nickname = "")
        {
            var userRecord = new UserRecord
            {
                Login = login,
                Password = password.Encrypt(),
                Nickname = nickname,
                Status = UserStatusString
            };

            var ans = from v
                      in Container.UserRecordSet
                      where v.Login == login
                      select v;

            if (ans.Count() == 0)
                throw new UserNotRegisteredException();

            Container.UserRecordSet.Add(userRecord);
            Container.SaveChanges();

            return new User(userRecord);
        }

        public User Login(string login, string password)
        {
            var encryptedPassword = password.Encrypt();

            var ans = from v
                      in Container.UserRecordSet
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

        public IEnumerable<ArticleRecord> ArticleRecords => Container.ArticleRecordSet.AsEnumerable();
        
        private const string UserStatusString = "user";
        private const string ModeratorStatusString = "moderator";
        private const string AdministratorStatusString = "administrator";

        public PermGuideContainer Container { get; internal set; }

        private Dictionary<Type, object> mSets;
    }
}
