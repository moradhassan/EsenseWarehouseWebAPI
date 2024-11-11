using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WarehouseWebAPI.Data
{
    public class WareHouseContext :IdentityDbContext<ApplicationUser>
    {
        private readonly IConfiguration config;

        public WareHouseContext(IConfiguration _config)
        {
            config = _config;
        }

        public DbSet<Warehouse> Warehouse { get; set; } 
        public DbSet<Product> Products { get; set; } 
        public DbSet<Order> Orders { get; set; } 

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(config.GetConnectionString("WareHouseString"))
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            base.OnConfiguring(optionsBuilder);
        }
    }
}
