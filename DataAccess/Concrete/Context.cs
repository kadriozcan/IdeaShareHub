using Entity;
using Entity.Concrete;
using System.Data.Entity;

namespace DataAccess.Concrete
{
    public class Context : DbContext
    {
        public DbSet<About> Abouts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Content> Contents { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Writer> Writers { get; set; }
    }
}
