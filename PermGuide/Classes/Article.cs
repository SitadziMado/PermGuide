using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PermGuide.Classes
{
    public class Article : BaseContent
    {
        internal Article(DatabaseManager man, ArticleRecord articleRecord) :
            base(man, articleRecord)
        {
        }

        public MediaFile GetHtml()
        {
            try
            {
                return new MediaFile(
                    Manager, 
                    (
                        from v
                        in ArticleRecord.FileRecord
                        where v.MediaType == MediaType.Html
                        select v
                    ).Single()
                 );
            }
            catch (InvalidOperationException e)
            {
                throw new FileNotFoundException(
                    "Файл с типом \"HTML\" не был найден.", e
                );
            }
            catch
            {
                throw;
            }
        }

        public Article AddFile(User sender, string uri, MediaType mediaType)
        {
            if (!sender.Owns(this))
                throw new AccessDeniedException();

            var record = new FileRecord
            {
                Uri = uri,
                MediaType = mediaType,
                ArticleRecord = ArticleRecord,
                UserRecord = sender.UserRecord
            };

            ArticleRecord.FileRecord.Add(record);
            sender.UserRecord.FileRecord.Add(record);

            return this;
        }

        public Article RemoveFile(User sender, MediaFile file)
        {
            if (!sender.Owns(this))
                throw new AccessDeniedException();
            
            var record = file.FileRecord;

            ArticleRecord.FileRecord.Remove(record);
            sender.UserRecord.FileRecord.Remove(record);

            return this;
        }

        private IEnumerable<MediaFile> GetUrisByMediaType(MediaType mediaType)
        {
            return from v
                   in ArticleRecord.FileRecord
                   where v.MediaType == mediaType
                   select new MediaFile(Manager, v);
        }

        public string Name => Record.Name;
        public IEnumerable<MediaFile> ImageUris => GetUrisByMediaType(MediaType.Image);
        public IEnumerable<MediaFile> AudioUris => GetUrisByMediaType(MediaType.Audio);
        public IEnumerable<MediaFile> VideoUris => GetUrisByMediaType(MediaType.Video);

        internal ArticleRecord ArticleRecord => Record as ArticleRecord;
    }
}
