using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PermGuide.Classes
{
    class Moderator : User
    {
        internal Moderator(UserRecord userRecord) :
            base(userRecord)
        {

        }

        public void Add(IContent content)
        {
            var record = content.GetRecord();

            record.Id = Guid.NewGuid();
            record.ProposalStatus = ProposalStatus.Added;
            record.UserRecord = UserRecord;

            Manager.Container.ContentRecordSet.Add(record);
            Manager.Container.SaveChanges();
        }

        public void Process(IContent content, ProposalStatus status)
        {
            var record = content.GetRecord();

            record.ProposalStatus = status;
            Manager.Container.SaveChanges();
        }

        /* Moderator
         ***********
         / GetSights()
         V Add(IProposable)
         / GetExcursions()
         V Accept(IProposable)
         / GetArticles()
         */
    }
}
