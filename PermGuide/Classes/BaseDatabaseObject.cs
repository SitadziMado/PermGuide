using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PermGuide.Classes
{
    abstract class BaseDatabaseObject
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

        public DatabaseManager Manager { get; private set; }
    }
}
