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
        internal Excursion(ExcursionRecord excursionRecord) :
            base(excursionRecord)
        {

        }

        public void AddSights(User sender, IEnumerable<Sight> sights)
        {
            if (!sender.Owns(this))
                throw new AccessDeniedException();

            foreach (var v in sights)
                ExcursionRecord.SightRecord.Add(v.SightRecord);

            sender.SaveChanges();
        }

        public void RemoveSights(User sender, IEnumerable<Sight> sights)
        {
            if (!sender.Owns(this))
                throw new AccessDeniedException();

            foreach (var v in sights)
                ExcursionRecord.SightRecord.Remove(v.SightRecord);

            sender.SaveChanges();
        }

        public void SetArticle(User sender, Article article)
        {
            if (!sender.Owns(this))
                throw new AccessDeniedException();

            ExcursionRecord.ArticleRecord = article.ArticleRecord;

            sender.SaveChanges();
        }

        public IEnumerable<DbGeography> Points 
            => from v in ExcursionRecord.SightRecord select v.Location;

        internal ExcursionRecord ExcursionRecord => Record as ExcursionRecord;
    }
}
