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

            Manager.Container.SaveChanges();
        }

        public HashSet<Article> GetArticles()
            => GetHashSetOfRecords<Article, ArticleRecord>(x => x.ProposalStatus == ProposalStatus.Added);

        public HashSet<Excursion> GetExcursions()
            => GetHashSetOfRecords<Excursion, ExcursionRecord>(x => x.ProposalStatus == ProposalStatus.Added);

        public HashSet<Sight> GetSights()
            => GetHashSetOfRecords<Sight, SightRecord>(x => x.ProposalStatus == ProposalStatus.Added);

        public HashSet<Timetable> GetTimetables() => GetHashSetOfRecords<Timetable, TimetableRecord>();

        public void LeaveReview(IContent content, int mark, string comment)
        {
            ReviewRecord record = new ReviewRecord
            {
                // Id = Guid.NewGuid(),
                CreationDate = DateTime.Now,
                Mark = $"{mark}: {comment}",
                UserRecord = UserRecord,
                ContentRecord = content.GetRecord()
            };

            Manager.Container.ReviewRecordSet.Add(record);
            Manager.Container.SaveChanges();
        }

        public void Propose(IContent content)
        {
            var record = content.GetRecord();

            // record.Id = Guid.NewGuid();
            record.ProposalStatus = ProposalStatus.Proposed;
            record.UserRecord = UserRecord;

            Manager.Container.ContentRecordSet.Add(record);
            Manager.Container.SaveChanges();
        }

        protected HashSet<T> GetHashSetOfRecords<T, U>()
            where T : class
            where U : class
        {
            return GetHashSetOfRecords<T, U>(x => true);
        }

        protected HashSet<T> GetHashSetOfRecords<T, U>(Predicate<U> predicate)
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

        /* User
         ******
         V GetSightPoints()
         V LeaveReview(IReviewable) where IReviewable = { Sight, Excursion }
         V GetExcursionsInfo()
         V Propose(IProposable) where IProposable = { Sight, Excursion, Article }
         V GetArticleInfo()
         X UploadMedia(File)
         V GetTimetableInfo()
         */

        public static readonly User Empty = 
            new User(new UserRecord { Login = "undefined", Password = "undefined" });

        public DatabaseManager Manager { get; set; }
        internal UserRecord UserRecord { get; private set; }

        public bool Valid => Manager.Container.UserRecordSet.Contains(UserRecord);
    }
}