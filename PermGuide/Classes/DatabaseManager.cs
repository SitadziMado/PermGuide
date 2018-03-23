using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PermGuide.Classes
{
    public sealed class DatabaseManager
    {
        public DatabaseManager()
        {
            Container = new PermGuideContainer();

            mSets = new Dictionary<Type, object>();

            // При добавлении класса следует обновить
            /*mSets = new Dictionary<Type, object>
            {
                { typeof(ArticleRecord), Container.ContentRecordSet }, // ArticleRecordSet },
                { typeof(ExcursionRecord), Container.ContentRecordSet }, // ExcursionRecordSet },
                { typeof(FileRecord), Container.FileRecordSet },
                { typeof(RegionRecord), Container.RegionRecordSet },
                { typeof(ReviewRecord), Container.ReviewRecordSet },
                { typeof(SightRecord), Container.ContentRecordSet }, // SightRecordSet },
                { typeof(TimetableRecord), Container.TimetableRecordSet },
                { typeof(UserRecord), Container.UserRecordSet },

                { typeof(DbSet<ArticleRecord>), Container.ContentRecordSet }, // ArticleRecordSet },
                { typeof(DbSet<ExcursionRecord>), Container.ContentRecordSet }, // ExcursionRecordSet },
                { typeof(DbSet<FileRecord>), Container.FileRecordSet },
                { typeof(DbSet<RegionRecord>), Container.RegionRecordSet },
                { typeof(DbSet<ReviewRecord>), Container.ReviewRecordSet },
                { typeof(DbSet<SightRecord>), Container.ContentRecordSet }, // SightRecordSet },
                { typeof(DbSet<TimetableRecord>), Container.TimetableRecordSet },
                { typeof(DbSet<UserRecord>), Container.UserRecordSet },
            };*/

            var thisAsm = Assembly.GetExecutingAssembly();
            var contType = Container.GetType();

            var keys = from v
                       in thisAsm.DefinedTypes
                       where v.Name != "Record" && v.Name.Contains("Record")
                       select v;

            var values = from v
                         in contType.GetProperties()
                         where v.Name.Contains("RecordSet")
                         select v;

            foreach (var k in keys)
                foreach (var v in values)
                {
                    var vType = v.PropertyType.GenericTypeArguments[0];

                    if (k.IsSubclassOf(vType) || k == vType)
                        mSets.Add(k, v.GetValue(Container));
                }
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
                // Id = Guid.Empty,
                Login = login,
                Password = password.Encrypt(),
                Nickname = nickname,
                Status = UserStatus.User,
                BanStatus = new BanStatus
                {
                    IsBanned = false,
                    BannedTill = DateTime.Now
                }
            };

            var ans = from v
                      in Container.UserRecordSet
                      where v.Login == login
                      select v;

            if (ans.Count() != 0)
                throw new UserNotRegisteredException();
            
            Container.UserRecordSet.Add(userRecord);
            Container.SaveChanges();

            return new User(this, userRecord);
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
                result = new User(this, ans.Single());

                /*var rec = ans.Single();

                switch (rec.Status)
                {
                    case UserStatus.User: result = new User(rec); break;
                    case UserStatus.Moderator: result = new Moderator(rec); break;
                    case UserStatus.Administrator: result = new Administrator(rec); break;
                    default: throw new UserNotRegisteredException();
                }*/
            }
            catch (InvalidOperationException)
            {
                throw new UserNotRegisteredException();
            }

            return result;
        }

        public void TestQueryConstructor()
        {
            /* QueryConstructor qc = new QueryConstructor(
                "ArticleRecord",
                "ContentRecord",
                "ExcursionRecord",
                "FileRecord",
                "RegionRecord",
                "ReviewRecord",
                "SightRecord",
                "TimetableRecord",
                "UserRecord"
            );

            var root = qc.GetAttributes("UserRecord");

            root.Children[1].Criterium = "sunmax1234@mail.ru";

            var query = qc.Query(Container.UserRecordSet, root).ToArray(); */
            
        }

        public IEnumerable<ArticleRecord> ArticleRecords =>
            from v
            in Container.ContentRecordSet // ArticleRecordSet.AsEnumerable();
            where v is ArticleRecord
            select v as ArticleRecord;
        
        /* private const string UserStatusString = "user";
        private const string ModeratorStatusString = "moderator";
        private const string AdministratorStatusString = "administrator"; */

        public PermGuideContainer Container { get; internal set; }

        private Dictionary<Type, object> mSets;
    }
}
