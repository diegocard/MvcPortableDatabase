
namespace PortableDatabaseExample.Models
{
    public class SqlCEContext : TaskContext
    {
        public SqlCEContext()
            : base("SQL_CE_Connection")
        {

        }
    }
}