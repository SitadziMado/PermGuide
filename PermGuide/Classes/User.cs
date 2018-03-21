using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PermGuide.Classes
{
    class User
    {
        internal User(UserRecord userRecord)
        {
            UserRecord = userRecord;
        }

        public void UpdateData(string login, string password, string nickname)
        {
            if (!Valid)
                throw new RecordNotValidException();

            UserRecord.Login = login;
            UserRecord.Password = password.Encrypt();
            UserRecord.Nickname = nickname;

            SaveChanges();
        }

        public HashSet<Article> GetArticles()
            => GetHashSetOfRecords<Article, ArticleRecord>(x => x.ProposalStatus == ProposalStatus.Added);

        public HashSet<Excursion> GetExcursions()
            => GetHashSetOfRecords<Excursion, ExcursionRecord>(x => x.ProposalStatus == ProposalStatus.Added);

        public HashSet<Sight> GetSights()
            => GetHashSetOfRecords<Sight, SightRecord>(x => x.ProposalStatus == ProposalStatus.Added);

        public HashSet<Timetable> GetTimetables() => GetHashSetOfRecords<Timetable, TimetableRecord>();

        public void ChangeStatus(User other, UserStatus status)
        {
            if (!IsAdmin)
                throw new AccessDeniedException();

            other.UserRecord.Status = status;
            SaveChanges();
        }

        public void Ban(User other, DateTime tillWhen)
        {
            if (!IsAdmin)
                throw new AccessDeniedException();

            other.UserRecord.BanStatus.IsBanned = true;
            other.UserRecord.BanStatus.BannedTill = tillWhen;
            SaveChanges();
        }

        public HashSet<Review> GetComplaints()
        {
            if (!IsAdmin)
                throw new AccessDeniedException();

            return GetHashSetOfRecords<Review, ReviewRecord>(x => x.Mark == "");
        }

        public bool Owns(BaseContent content)
            => UserRecord == content.Record.UserRecord;

        public void SaveChanges()
        {
            Manager.Container.SaveChanges();
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

        public static readonly User Empty = 
            new User(new UserRecord { Login = "undefined", Password = "undefined" });

        public bool IsAdmin => Status == UserStatus.Administrator;
        public bool IsModerator => IsAdmin || Status == UserStatus.Moderator;
        public DatabaseManager Manager { get; set; }
        public UserStatus Status => UserRecord.Status;
        internal UserRecord UserRecord { get; private set; }

        public bool Valid => Manager.Container.UserRecordSet.Contains(UserRecord);
    }
}