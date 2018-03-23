using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PermGuide.Classes
{
    public abstract class BaseDatabaseObject
    {
        internal BaseDatabaseObject(DatabaseManager databaseManager)
        {
            Manager = databaseManager;
        }

        public BaseDatabaseObject Commit()
        {
            try
            {
                Manager.Container.SaveChanges();
            }
            catch
            {
                throw;
            }

            return this;
        }

        protected int GetNextId()
        {
            int result;

            lock (mIdLock)
            {
                result = mId++;
            }

            return result;
        }

        public DatabaseManager Manager { get; private set; }
        private static object mIdLock = new object();
        private static int mId = 1;
    }
}
