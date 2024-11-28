using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data.Entity;
using System.Data.Entity.SqlServer;

namespace DataAccessLayer
{
    internal class Context : DbContext
    {
        public Context() : base("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\medka\\Desktop\\3 семак\\AIS\\Laba2Sem3AIS\\Laba2Sem3AIS\\Laba1_Sem3\\Laba1_Sem3\\DataAccessLayer\\Database1.mdf\";Integrated Security=True") 
        {
            var ensureDLLIsCopied = SqlProviderServices.Instance;
        }

        public DbSet<Student> Students { get; set; }
    }
}
