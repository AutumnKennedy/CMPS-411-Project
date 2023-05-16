using HelpfulNeighbor.web.Features.Centers;
using HelpfulNeighbor.web.Features.Centers.CenterType;
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

        public DbSet<DonationCenter> DonationCenter { get; set; }
        public DbSet<DonationCenterType> DonationCenterType { get; set; }
        public DbSet<EducationCenter> EducationCenter { get; set; }
        public DbSet<EducationCenterType> EducationCenterType { get; set; }
        public DbSet<MailCenter> MailCenter { get; set; }
        public DbSet<MentalHealthTreatmentCenter> MentalHealthTreatmentCenter { get; set; }
        public DbSet<MentalHealthTreatmentCenterType> MentalHealthTreatmentCenterType { get; set; }
        public DbSet<Shelter> Shelter { get; set; }
        public DbSet<ShelterType> ShelterType { get; set; }
        public DbSet<SubstanceAbuseTreatmentCenter> SubstanceAbuseTreatmentCenter { get; set; }
        public DbSet<SubstanceAbuseTreatmentCenterType> SubstanceAbuseTreatmentCenterType { get; set; }


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
