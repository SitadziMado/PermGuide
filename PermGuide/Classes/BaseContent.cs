using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PermGuide.Classes
{
    abstract class BaseContent : BaseDatabaseObject
    {
        internal BaseContent(
            DatabaseManager man, 
            ContentRecord contentRecord
        ) : base(man)
        {
            Record = contentRecord;
        }

        public BaseContent SetName(User sender, string name)
        {
            if (!sender.Owns(this))
                throw new AccessDeniedException();

            Record.Name = name;

            return this;
        }

        public BaseContent Review(User sender, int mark, string comment)
        {
            ReviewRecord record = new ReviewRecord
            {
                CreationDate = DateTime.Now,
                Mark = $"{mark}: {comment}",
                UserRecord = sender.UserRecord,
                ContentRecord = Record
            };

            // Добавить ассоциации
            sender.UserRecord.ReviewRecord.Add(record);
            Record.ReviewRecord.Add(record);

            Manager.Container.ReviewRecordSet.Add(record);

            return this;
        }

        public BaseContent Process(User sender, ProposalStatus status)
        {
            if (!sender.IsModerator)
                throw new AccessDeniedException();

            var record = Record;

            record.ProposalStatus = status;

            return this;
        }

        internal ContentRecord Record { get; set; }
    }
}
