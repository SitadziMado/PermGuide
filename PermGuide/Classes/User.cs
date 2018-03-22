using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PermGuide.Classes
{
    class User : BaseDatabaseObject
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

        public HashSet<Article> GetArticles()
            => GetHashSetOfRecords<Article, ArticleRecord>(x => x.ProposalStatus == ProposalStatus.Added);

        public HashSet<Excursion> GetExcursions()
            => GetHashSetOfRecords<Excursion, ExcursionRecord>(x => x.ProposalStatus == ProposalStatus.Added);

        public HashSet<Sight> GetSights()
            => GetHashSetOfRecords<Sight, SightRecord>(x => x.ProposalStatus == ProposalStatus.Added);

        public HashSet<Timetable> GetTimetables() => GetHashSetOfRecords<Timetable, TimetableRecord>();

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

        public HashSet<Review> GetComplaints()
        {
            if (!IsAdmin)
                throw new AccessDeniedException();

            return GetHashSetOfRecords<Review, ReviewRecord>(x => x.Mark == "");
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

        public User Propose(BaseContent content)
        {
            if (!IsModerator)
                throw new AccessDeniedException();

            var record = content.Record;

            record.ProposalStatus = ProposalStatus.Proposed;
            record.UserRecord = UserRecord;

            // Добавить ассоциации
            UserRecord.ContentRecord.Add(record);

            Manager.Container.ContentRecordSet.Add(record);

            return this;
        }

        public User Add(BaseContent content)
        {
            if (!IsModerator)
                throw new AccessDeniedException();

            var record = content.Record;

            record.ProposalStatus = ProposalStatus.Added;
            record.UserRecord = UserRecord;

            // Добавить ассоциации
            UserRecord.ContentRecord.Add(record);

            Manager.Container.ContentRecordSet.Add(record);

            return this;
        }

        private HashSet<T> GetHashSetOfRecords<T, U>()
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
        }

        public bool IsAdmin => Status == UserStatus.Administrator;
        public bool IsModerator => IsAdmin || Status == UserStatus.Moderator;
        public UserStatus Status => UserRecord.Status;
        internal UserRecord UserRecord { get; private set; }
    }
}