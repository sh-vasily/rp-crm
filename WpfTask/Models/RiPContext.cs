using System.Data.Entity;   

namespace WpfTask.Models
{
    class RiPContext : DbContext
    {
        public RiPContext() : base("DefaultConnection")
        {

        }

        public DbSet<Company> Companys { get; set; }
    }
}
