using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace EntityFramework.Context.Configurations
{
    public class BillTypeConfiguration : IEntityTypeConfiguration<BillType>
    {
        public void Configure(EntityTypeBuilder<BillType> builder)
        {
            builder.ToTable("BillTypes");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired();

            builder.HasData(Seed());

        }

        /*Uygulama ilk ayağa kaltığında tabloda olmasını istediğim verileri burada belirliyoruz.*/
        private List<BillType> Seed()
        {
            var list = new List<BillType>();
            BillType e = new BillType()
            {
                Id = 1,
                Name = "Tanımsız",
                DateCreated = System.DateTime.Now,
                IsActive = true
            };
            list.Add(e);

            BillType e0 = new BillType()
            {
                Id = 2,
                Name = "Aidat",
                DateCreated = System.DateTime.Now,
                IsActive = true
            };
            list.Add(e0);

            BillType e1 = new BillType()
            {
                Id = 3,
                Name = "Elektrik",
                DateCreated = System.DateTime.Now,
                IsActive = true
            };
            list.Add(e1);

            BillType e2 = new BillType()
            {
                Id = 4,
                Name = "Su",
                DateCreated = System.DateTime.Now,
                IsActive = true
            };
            list.Add(e2);

            BillType e3 = new BillType()
            {
                Id = 5,
                Name = "Doğal Gaz",
                DateCreated = System.DateTime.Now,
                IsActive = true
            };
            list.Add(e3);

            BillType e4 = new BillType()
            {
                Id = 6,
                Name = "Diğer",
                DateCreated = System.DateTime.Now,
                IsActive = true
            };
            list.Add(e4);                 
         

            return list;

        }
    }
}
