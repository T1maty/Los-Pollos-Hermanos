using Los_Pollos_Hermanos.Helpers.Seed;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Los_Pollos_Hermanos.Models
{
    public class LosPollosHermanosContext : IdentityDbContext<User, AppRole, int>
    {
        public LosPollosHermanosContext(DbContextOptions<LosPollosHermanosContext> options)
            : base(options)
        {

        }
        public override DbSet<User> Users { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Table> Tables { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder
                .UseSqlServer("Server=.\\SQLExpress;Database=userdb;Trusted_Connection=true;");
        }

    }
}

    
    

