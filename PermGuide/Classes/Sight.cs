using Microsoft.Maps.MapControl.WPF;
using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PermGuide.Classes
{
    public class Sight : BaseContent
    {
        internal Sight(DatabaseManager man, SightRecord sightRecord) :
            base(man, sightRecord)
        {

        }

        public Sight(User user) :
            base(user.Manager, new SightRecord())
        {
            SightRecord.Id = GetNextId();
            SightRecord.UserRecord = user.UserRecord;
        }

        public Sight SetLocation(User sender, Location location)
        {
            if (!sender.Owns(this))
                throw new AccessDeniedException();

            SightRecord.Location = location.ToString();

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

        public Location Point => SightRecord.Location.AsLocation();

        internal SightRecord SightRecord => Record as SightRecord;
    }
}
