using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SolarLabDR.Domain;


namespace SolarLabDR.DataAccess.Configuration
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(1000).IsRequired();
            builder.Property(x => x.LastName).HasMaxLength(1000).IsRequired();
            builder.Property(x => x.Date).IsRequired();
        }
    }
}
