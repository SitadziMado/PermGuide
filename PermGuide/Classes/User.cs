using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PermGuide.Classes
{
    public class User : BaseDatabaseObject
    {
        internal User(DatabaseManager man, UserRecord userRecord) : 
            base(man)
        {
            UserRecord = userRecord;
        }

        public User SetLogin(string value)
        {
            UserRecord.Login = value;
            return this;
        }

        public User SetPassword(string value)
        {
            UserRecord.Password = value.Encrypt();
            return this;
        }

        public User SetNickname(string value)
        {
            UserRecord.Nickname = value;
            return this;
        }
        
        public User VerifyLogin(string value)
        {
            if (value.Length == 0)
                throw new ArgumentException("Пустая строка -- некорректниый логин.");

            return this;
        }

        public User VerifyPassword(string value)
        {
            if (value.Length == 0)
                throw new ArgumentException("Пустая строка -- некорректниый логин.");

            return this;
        }

        public User VerifyNickname(string value)
        {
            return this;
        }

        /* public HashSet<Article> GetArticles()
            => GetHashSetOfRecords<Article, ArticleRecord>(x => x.ProposalStatus == ProposalStatus.Added);

        public HashSet<Excursion> GetExcursions()
            => GetHashSetOfRecords<Excursion, ExcursionRecord>(x => x.ProposalStatus == ProposalStatus.Added);

        public HashSet<Sight> GetSights()
            => GetHashSetOfRecords<Sight, SightRecord>(x => x.ProposalStatus == ProposalStatus.Added); */

        // public HashSet<Timetable> GetTimetables() => GetHashSetOfRecords<Timetable, TimetableRecord>();

        public IEnumerable<Article> GetArticles()
        {
            var result = from v
                         in Manager.Container.ContentRecordSet
                         where v is ArticleRecord && v.ProposalStatus == ProposalStatus.Added
                         select v as ArticleRecord;
            
            return from v
                   in result.AsEnumerable()
                   select new Article(Manager, v);
        }

        public IEnumerable<Excursion> GetExcursions()
        {
            var result =  from v
                          in Manager.Container.ContentRecordSet
                          where v is ExcursionRecord && v.ProposalStatus == ProposalStatus.Added
                          select v as ExcursionRecord;

            return from v
                   in result.AsEnumerable()
                   select new Excursion(Manager, v);
        }

        public IEnumerable<Sight> GetSights()
        {
            var result = from v
                         in Manager.Container.ContentRecordSet
                         where v is SightRecord && v.ProposalStatus == ProposalStatus.Added
                         select v as SightRecord;

            return from v
                   in result.AsEnumerable()
                   select new Sight(Manager, v);
        }

        public IEnumerable<Timetable> GetTimetables()
        {
            return from v
                   in Manager.Container.TimetableRecordSet
                   select new Timetable(Manager, v);
        }

            public User ChangeStatus(User other, UserStatus status)
        {
            if (!IsAdmin)
                throw new AccessDeniedException();

            other.UserRecord.Status = status;

            return this;
        }

        public User Ban(User other, DateTime tillWhen)
        {
            if (!IsAdmin)
                throw new AccessDeniedException();

            other.UserRecord.BanStatus.IsBanned = true;
            other.UserRecord.BanStatus.BannedTill = tillWhen;

            return this;
        }

        // public HashSet<Review> GetComplaints()

        public IEnumerable<Review> GetComplaints()
        {
            if (!IsAdmin)
                throw new AccessDeniedException();

            return from v
                   in Manager.Container.ReviewRecordSet
                   where v.Mark == ""
                   select new Review(Manager, v);

            // return GetHashSetOfRecords<Review, ReviewRecord>(x => x.Mark == "");
        }

        public bool Owns(BaseContent content)
            => UserRecord == content.Record.UserRecord;

        public User CreateTimetable(string name)
        {
            var record = new TimetableRecord
            {
                // Name = name,
                CreationDate = DateTime.Now,
                UserRecord = UserRecord
            };

            // Добавить ассоциации
            UserRecord.TimetableRecord.Add(record);

            Manager.Container.TimetableRecordSet.Add(record);

            return this;
        }

        public User Add(BaseContent content)
        {
            var record = content.Record;

            record.UserRecord = UserRecord;

            // Добавить ассоциации
            UserRecord.ContentRecord.Add(record);

            record.ProposalStatus = IsModerator
                ? ProposalStatus.Added
                : ProposalStatus.Proposed;

            Manager.Container.ContentRecordSet.Add(record);

            return this;
        }

        /* private HashSet<T> GetHashSetOfRecords<T, U>()
            where T : class
            where U : class
        {
            return GetHashSetOfRecords<T, U>(x => true);
        }

        private HashSet<T> GetHashSetOfRecords<T, U>(Predicate<U> predicate)
            where T : class
            where U : class
        {
            HashSet<T> result;

            try
            {
                result = new HashSet<T>(
                    from v
                    in Manager.GetRecordSet<U>().AsEnumerable()
                    where predicate(v)
                    select (T)Activator.CreateInstance(typeof(T), v) // new T(v)
                );
            }
            catch
            {
                throw;
            }

            return result;
        } */

        public bool IsAdmin => Status == UserStatus.Administrator;
        public bool IsModerator => IsAdmin || Status == UserStatus.Moderator;
        public UserStatus Status => UserRecord.Status;
        internal UserRecord UserRecord { get; private set; }
    }
}