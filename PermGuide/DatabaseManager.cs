using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PermGuide
{
    class DatabaseManager 
    {
        private DatabaseManager() {}

        public bool Exists<T>(T item) where T : class
        {
            DbSet<T> set = GetRecordSet<T>();
            return set.Contains(item);
        }

        private DbSet<T> GetRecordSet<T>() where T: class
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

        public IEnumerable<ArticleRecord> ArticleRecords => Container.ArticleRecordSet.AsEnumerable();

        public static readonly DatabaseManager Manager = new DatabaseManager();
        public static readonly PermGuideContainer Container = new PermGuideContainer();
        private static Dictionary<Type, object> mSets = new Dictionary<Type, object>
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
}
