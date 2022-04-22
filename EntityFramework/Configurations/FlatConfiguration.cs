using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFramework.Context.Configurations
{
    public class FlatConfiguration : IEntityTypeConfiguration<Flat>
    {
        public void Configure(EntityTypeBuilder<Flat> builder)
        {
            builder.ToTable("Flats");
            builder.HasKey(x => x.Id);
        }
    }
}
