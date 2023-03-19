using DataAccessLayer.DataTable;
using Microsoft.EntityFrameworkCore;

namespace WebProductManagement.MVC.Data
{
    public class SolarPanelContext : DbContext
    {
        public DbSet<Location> Locations { get; set; } = null;
        public DbSet<Product> Products { get; set; } = null;
        public DbSet<ProjectDetails> ProjectDetails { get; set; } = null;
        public DbSet<ProjectProductList> ProjectProductLists { get; set; } = null;
        public DbSet<ProjectStatus> ProjectStatuses { get; set; } = null;
        public DbSet<Warehouse> Warehouses { get; set; } = null;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Connection String Here");
        }
    }
}
