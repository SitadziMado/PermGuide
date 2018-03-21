using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PermGuide.Classes
{
    abstract class BaseContent
    {
        public BaseContent(ContentRecord contentRecord)
        {
            Record = contentRecord;
        }

        public void Review(User sender, int mark, string comment)
        {
            ReviewRecord record = new ReviewRecord
            {
                // Id = Guid.NewGuid(),
                CreationDate = DateTime.Now,
                Mark = $"{mark}: {comment}",
                UserRecord = sender.UserRecord,
                ContentRecord = Record
            };

            sender.Manager.Container.ReviewRecordSet.Add(record);
            sender.SaveChanges();
        }

        public void Propose(User sender, BaseContent content)
        {
            if (!sender.IsModerator)
                throw new AccessDeniedException();

            var record = Record;

            // record.Id = Guid.NewGuid();
            record.ProposalStatus = ProposalStatus.Proposed;
            record.UserRecord = sender.UserRecord;

            sender.Manager.Container.ContentRecordSet.Add(record);
            sender.SaveChanges();
        }

        public void Add(User sender, BaseContent content)
        {
            if (!sender.IsModerator)
                throw new AccessDeniedException();

            var record = Record;

            // record.Id = Guid.NewGuid();
            record.ProposalStatus = ProposalStatus.Added;
            record.UserRecord = sender.UserRecord;

            sender.Manager.Container.ContentRecordSet.Add(record);
            sender.SaveChanges();
        }

        public void Process(User sender, BaseContent content, ProposalStatus status)
        {
            if (!sender.IsModerator)
                throw new AccessDeniedException();

            var record = Record;

            record.ProposalStatus = status;
            sender.SaveChanges();
        }

        internal ContentRecord Record { get; set; }
    }
}
