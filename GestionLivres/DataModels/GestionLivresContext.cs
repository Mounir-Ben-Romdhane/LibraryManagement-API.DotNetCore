using GestionLivres.DomainModels;
using Microsoft.EntityFrameworkCore;

namespace GestionLivres.DataModels
{
    public class GestionLivresContext : DbContext
    {
        public GestionLivresContext(DbContextOptions<GestionLivresContext> options) : base(options)
        {
        }

        public DbSet<Livre> Livres { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<CLaim> Claims { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
