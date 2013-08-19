
namespace PortableDatabaseExample.Models
{
    public class SQLiteContext : TaskContext
    {
        public SQLiteContext()
            : base("SQLite_Connection")
        {

        }
    }
}