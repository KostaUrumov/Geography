using GeographyStracture.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GeorgaphyStracture.Data
{
    public class GeographyDb : IdentityDbContext
    {
        public GeographyDb(DbContextOptions<GeographyDb> options)
            : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Continent>()
                .HasData(seedContinents());
                
            
            base.OnModelCreating(builder);
        }

        public DbSet<City> Cities { get; set; } = null!;
        public DbSet<Continent> Continents { get; set; } = null!;
        public DbSet<Country> Countries { get; set; } = null!;
        public DbSet<House> Houses { get; set; } = null!;
        public DbSet<Street> Streets { get; set; } = null!;

        private List<Continent> seedContinents()
        {
            Continent one = new Continent()
            {
                Id = 1,
                Name = "Africa",
                Countries = new List<Country>(),
                PctureUrl = "https://img.theculturetrip.com/1440x807/smart/wp-content/uploads/2017/06/africa-main.jpg"

            };

            Continent two = new Continent()
            {
                Id = 2,
                Name = "Asia",
                Countries = new List<Country>(),
                PctureUrl = "https://images.unsplash.com/photo-1513415564515-763d91423bdd?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=435&q=80"

            };

            Continent three = new Continent()
            {
                Id = 3,
                Name = "Europe",
                Countries = new List<Country>(),
                PctureUrl = "https://images.unsplash.com/photo-1608817576203-3c27ed168bd2?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=992&q=80"

            };

            Continent four = new Continent()
            {
                Id = 4,
                Name = "Noth America",
                Countries = new List<Country>(),
                PctureUrl = "https://cdn2.wanderlust.co.uk/media/1202/dreamstime_xxl_45275518.jpg?anchor=center&mode=crop&width=1440&height=643&format=auto&rnd=131455360060000000"

            };

            Continent five = new Continent()
            {
                Id = 5,
                Name = "South America",
                Countries = new List<Country>(),
                PctureUrl = "https://www.trafalgar.com/media/k1xpowj0/icons-south-america-guided-tour-1.jpg?center=0.5%2C0.5&format=webp&mode=crop&width=900&height=900&quality=80"
            };
            List<Continent> data = new List<Continent>();
            data.Add(one);
            data.Add(two);
            data.Add(three);
            data.Add(four);
            data.Add(five);

            return data;
        }
    }
}