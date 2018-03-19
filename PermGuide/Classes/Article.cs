using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PermGuide.Classes
{
    class Article : IContent, IProposable
    {
        internal Article(ArticleRecord articleRecord)
        {
            ArticleRecord = articleRecord;
        }

        public ArticleRecord ArticleRecord { get; private set; }
    }
}
