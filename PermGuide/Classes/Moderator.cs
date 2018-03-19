using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PermGuide.Classes
{
    class Moderator : User
    {
        public Moderator(UserRecord userRecord) :
            base(userRecord)
        {

        }

        /* Moderator
         ***********
         * GetSights()
         * Add(IProposable)
         * GetExcursions()
         * Accept(IProposable)
         * GetArticles()
         */
    }
}
