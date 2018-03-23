using Microsoft.Maps.MapControl.WPF;
using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PermGuide.Classes
{
    public class Excursion : BaseContent
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
            {
                ExcursionRecord.SightRecord.Add(v.SightRecord);
                v.SightRecord.ExcursionRecord.Add(ExcursionRecord);
            }

            return this;
        }

        public Excursion RemoveSights(User sender, IEnumerable<Sight> sights)
        {
            if (!sender.Owns(this))
                throw new AccessDeniedException();

            foreach (var v in sights)
            {
                ExcursionRecord.SightRecord.Remove(v.SightRecord);
                v.SightRecord.ExcursionRecord.Remove(ExcursionRecord);
            }

            return this;
        }

        public Excursion SetArticle(User sender, Article article)
        {
            if (!sender.Owns(this))
                throw new AccessDeniedException();

            ExcursionRecord.ArticleRecord = article.ArticleRecord;
            article.ArticleRecord.ExcursionRecord = ExcursionRecord;

            return this;
        }

        public IEnumerable<Location> Points 
            => from v in ExcursionRecord.SightRecord select v.Location.AsLocation();

        internal ExcursionRecord ExcursionRecord => Record as ExcursionRecord;
    }
}
