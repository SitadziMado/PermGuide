using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PermGuide.Classes
{
    class Excursion : BaseContent
    {
        internal Excursion(DatabaseManager man, ExcursionRecord excursionRecord) :
            base(man, excursionRecord)
        {

        }

        public Excursion AddSights(User sender, IEnumerable<Sight> sights)
        {
            if (!sender.Owns(this))
                throw new AccessDeniedException();

            foreach (var v in sights)
                ExcursionRecord.SightRecord.Add(v.SightRecord);

            return this;
        }

        public Excursion RemoveSights(User sender, IEnumerable<Sight> sights)
        {
            if (!sender.Owns(this))
                throw new AccessDeniedException();

            foreach (var v in sights)
                ExcursionRecord.SightRecord.Remove(v.SightRecord);

            return this;
        }

        public Excursion SetArticle(User sender, Article article)
        {
            if (!sender.Owns(this))
                throw new AccessDeniedException();

            ExcursionRecord.ArticleRecord = article.ArticleRecord;

            return this;
        }

        public IEnumerable<DbGeography> Points 
            => from v in ExcursionRecord.SightRecord select v.Location;

        internal ExcursionRecord ExcursionRecord => Record as ExcursionRecord;
    }
}
