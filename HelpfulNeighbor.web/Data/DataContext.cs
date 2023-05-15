using HelpfulNeighbor.web.Features.Shelters;
using HelpfulNeighbor.web.Features.Shelters.ShelterType;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace HelpfulNeighbor.web.Data
{
    public class DataContext : IdentityDbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        { 
        }

        public DbSet<Shelter> Shelter { get; set; }
        public DbSet<ShelterType> ShelterType { get; set; }

        public DataContext() 
        { 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);
        }

    }
}
