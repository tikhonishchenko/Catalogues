using Catalogues.Models;
using Microsoft.EntityFrameworkCore;

namespace Catalogues.Data
{
    internal sealed class AppDBContext : DbContext
    {
        public DbSet<CatalogueModel> Folders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=./Data/AppDB.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            CatalogueModel[] catalogues = new CatalogueModel[8];
            catalogues[0] = new CatalogueModel("Creating Digital Images", "Resources,Evidence,Graphic Products");
            catalogues[1] = new CatalogueModel("Resources", "Primary Sources,Secondary Sources");
            catalogues[2] = new CatalogueModel("Evidence", "");
            catalogues[3] = new CatalogueModel("Graphic Products", "Process,Final Product");
            catalogues[4] = new CatalogueModel("Primary Sources", "");
            catalogues[5] = new CatalogueModel("Secondary Sources", "");
            catalogues[6] = new CatalogueModel("Process", "");
            catalogues[7] = new CatalogueModel("Final Product", "");

            modelBuilder.Entity<CatalogueModel>().HasData(catalogues);
        }

    }
}
