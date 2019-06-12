using System.Data.Entity;   

namespace WpfTask.Models
{
    class RiPContext : DbContext
    {
        public RiPContext() : base("DefaultContext")
        {

        }

        public DbSet<Company> Companys { get; set; }
    }
}
