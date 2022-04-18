using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace EntityFramework.Context.Configurations
{
    public class BillConfiguration : IEntityTypeConfiguration<Bill>
    {
        public void Configure(EntityTypeBuilder<Bill> builder)
        {
            builder.ToTable("Bills");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.BillTypeId).IsRequired();
            builder.Property(x => x.Year).IsRequired();
            builder.Property(x => x.Mount).IsRequired();   

        }

 

    }
}
