using Microsoft.EntityFrameworkCore;
using SolarLabDR.DataAccess.Configuration;
using SolarLabDR.Domain;

namespace SolarLabDR.DataAccess
{
    public class DrDbContext : DbContext
    {
        public DrDbContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ImageConfiguration());
            modelBuilder.ApplyConfiguration(new PersonConfiguration());

            modelBuilder.Entity<Person>().HasData(
                new Person 
                { Id = Guid.Parse("01988eaa-649d-7ee3-b8ce-0291de8587be"),
                     Name = "Валерий",
                    LastName = "Славко",
                    Date = DateTime.Parse("2001-08-15 00:00:00+00").ToUniversalTime(),
                    Email = "slavko@mail.ru" 
                },
                new Person
                {
                    Id = Guid.Parse("019898fb-da44-7018-879c-b0826773613a"),
                    Name = "Петр",
                    LastName = "Корочаев",
                    Date = DateTime.Parse("1981-08-10 00:00:00+00").ToUniversalTime(),
                    Email = "testhendler@mail.ru"
                },
                new Person
                {
                    Id = Guid.Parse("0198990c-b2ff-711e-b008-135e3cdae65d"),
                    Name = "Ася",
                    LastName = "Бякина",
                    Date = DateTime.Parse("2003-08-17 00:00:00+00").ToUniversalTime(),
                    Email = "asin@mail.ru"
                },
                new Person
                {
                    Id = Guid.Parse("0198888d-6478-7548-848b-d5726a2dccc4"),
                    Name = "Вася",
                    LastName = "Букин",
                    Date = DateTime.Parse("2005-08-20 00:00:00+00").ToUniversalTime(),
                    Email = "bukin@mail.ru"
                });

            //modelBuilder.Entity<Image>().HasData(


        }
    }
}
