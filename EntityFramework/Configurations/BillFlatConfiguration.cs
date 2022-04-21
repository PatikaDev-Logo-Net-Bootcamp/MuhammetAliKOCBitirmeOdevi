using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace EntityFramework.Context.Configurations
{
    public class BillFlatConfiguration : IEntityTypeConfiguration<BillFlat>
    {
        public void Configure(EntityTypeBuilder<BillFlat> builder)
        {
            builder.ToTable("BillFlats");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.BillId).IsRequired();
            builder.Property(x => x.FlatId).IsRequired();
            builder.Property(x => x.Amount).IsRequired();

            //builder.Property(x => x.Amount).HasColumnType("decimal").IsRequired();

        }



    }
}
