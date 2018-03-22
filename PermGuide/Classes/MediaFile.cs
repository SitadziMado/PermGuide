using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PermGuide.Classes
{
    class MediaFile : BaseDatabaseObject
    {
        internal MediaFile(DatabaseManager man, FileRecord fileRecord) :
            base(man)
        {
            FileRecord = fileRecord;
        }

        // public MediaFile SetUri(string uri, MediaType mediaType);

        public object GetContent()
        {
            Uri uri = new Uri(FileRecord.Uri);
            object result;

            try
            {
                if (uri.IsFile)
                {
                    byte[] buffer = File.ReadAllBytes(uri.LocalPath);
                    result = buffer;
                }
                else // Web address
                {
                    

                    throw new NotImplementedException();
                }
            }
            catch (FileNotFoundException)
            {
                throw;
            }

            return result;
        }

        internal FileRecord FileRecord { get; private set; }
    }
}
