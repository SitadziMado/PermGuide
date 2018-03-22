using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PermGuide.Classes
{
    class Sight : BaseContent
    {
        internal Sight(DatabaseManager man, SightRecord sightRecord) :
            base(man, sightRecord)
        {

        }

        public Sight SetLocation(User sender, DbGeography location)
        {
            if (!sender.Owns(this))
                throw new AccessDeniedException();

            SightRecord.Location = location;

            return this;
        }

        public Sight SetAddress(User sender, string address)
        {
            if (!sender.Owns(this))
                throw new AccessDeniedException();

            SightRecord.Address = address;

            return this;
        }

        public Sight SetArticle(User sender, Article article)
        {
            if (!sender.Owns(this))
                throw new AccessDeniedException();

            SightRecord.ArticleRecord = article.ArticleRecord;
            article.ArticleRecord.SightRecord = SightRecord;

            return this;
        }

        public DbGeography Location => (Record as SightRecord).Location;

        internal SightRecord SightRecord => Record as SightRecord;
    }
}
