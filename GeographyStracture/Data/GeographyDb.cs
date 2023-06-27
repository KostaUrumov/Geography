using GeographyStracture.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GeorgaphyStracture.Data
{
    public class GeographyDb : IdentityDbContext<User>
    {
        public GeographyDb(DbContextOptions<GeographyDb> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>()
                .HasData(
                new IdentityRole {Id = "2c5e174e-3b0e-446f-86af-483d56fd7210", Name = "Administrator", NormalizedName = "ADMINISTRATOR".ToUpper() },
                new IdentityRole { Id = "2c93174e-3b0e-446f-86af-883d56fr7210", Name = "User", NormalizedName = "USER".ToUpper() }) ;

            builder.Entity<Continent>()
                .HasData(seedContinents());

            builder.Entity<UserCity>()
                .HasKey(a => new { a.CityId, a.UserId });

            builder.Entity<UserCountry>()
                .HasKey(a => new { a.CountryId, a.UserId });

            builder.Entity<UserMountain>()
                .HasKey(a => new { a.MountainId, a.UserId });

            builder.Entity<UserRiver>()
               .HasKey(a => new { a.RiverId, a.UserId });


            base.OnModelCreating(builder);
        }

        public DbSet<City> Cities { get; set; } = null!;
        public DbSet<Continent> Continents { get; set; } = null!;
        public DbSet<Country> Countries { get; set; } = null!;
        public DbSet<River> Rivers { get; set; } = null!;
        public DbSet<Mountaine> Mountines { get; set; } = null!;
        public DbSet<UserCity> UsersCities { get; set; } = null!;
        public DbSet<UserCountry> UsersCountries { get; set; } = null!;
        public DbSet<UserMountain> UsersMoutains { get; set; } = null!;
        public DbSet<UserRiver> UsersRvers { get; set; } = null!;

        private List<Continent> seedContinents()
        {
            Continent one = new Continent()
            {
                Id = 1,
                Name = "Africa",
                PctureUrl = "https://img.theculturetrip.com/1440x807/smart/wp-content/uploads/2017/06/africa-main.jpg"

            };

            Continent two = new Continent()
            {
                Id = 2,
                Name = "Asia",
                PctureUrl = "https://images.unsplash.com/photo-1513415564515-763d91423bdd?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=435&q=80"

            };

            Continent three = new Continent()
            {
                Id = 3,
                Name = "Europe",
                PctureUrl = "https://images.unsplash.com/photo-1608817576203-3c27ed168bd2?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=992&q=80"

            };

            Continent four = new Continent()
            {
                Id = 4,
                Name = "Noth America",
                PctureUrl = "https://cdn2.wanderlust.co.uk/media/1202/dreamstime_xxl_45275518.jpg?anchor=center&mode=crop&width=1440&height=643&format=auto&rnd=131455360060000000"

            };

            Continent five = new Continent()
            {
                Id = 5,
                Name = "South America",
                PctureUrl = "https://www.trafalgar.com/media/k1xpowj0/icons-south-america-guided-tour-1.jpg?center=0.5%2C0.5&format=webp&mode=crop&width=900&height=900&quality=80"
            };
            Continent six = new Continent()
            {
                Id = 6,
                Name = "Australia",
                PctureUrl = "https://www.nationsonline.org/gallery/Australia/Uluru-from-above-L.jpg"
            };
            List<Continent> data = new List<Continent>();
            data.Add(one);
            data.Add(two);
            data.Add(three);
            data.Add(four);
            data.Add(five);
            data.Add(six);

            return data;
        }

        
         

    }
}