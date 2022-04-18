using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace EntityFramework.Context.Configurations
{
    public class FlatTypeConfiguration : IEntityTypeConfiguration<FlatType>
    {
        public void Configure(EntityTypeBuilder<FlatType> builder)
        {
            builder.ToTable("FlatTypes");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired();

            builder.HasData(Seed());

        }

        /*Uygulama ilk ayağa kaltığında tabloda olmasını istediğim verileri burada belirliyoruz.*/
        private List<FlatType> Seed()
        {
            var list = new List<FlatType>();
            FlatType e = new FlatType()
            {
                Id = 1,
                Name = "Tanımsız",
                DateCreated = System.DateTime.Now,
                IsActive = true
            };
            list.Add(e);

            FlatType e0 = new FlatType()
            {
                Id = 2,
                Name = "1+0",
                DateCreated = System.DateTime.Now,
                IsActive = true
            };
            list.Add(e0);

            FlatType e1 = new FlatType()
            {
                Id = 3,
                Name = "1+1",
                DateCreated = System.DateTime.Now,
                IsActive = true
            };
            list.Add(e1);

            FlatType e2 = new FlatType()
            {
                Id = 4,
                Name = "2+0",
                DateCreated = System.DateTime.Now,
                IsActive = true
            };
            list.Add(e2);

            FlatType e3 = new FlatType()
            {
                Id = 5,
                Name = "2+1",
                DateCreated = System.DateTime.Now,
                IsActive = true
            };
            list.Add(e3);

            FlatType e4 = new FlatType()
            {
                Id = 6,
                Name = "3+0",
                DateCreated = System.DateTime.Now,
                IsActive = true
            };
            list.Add(e4);

            FlatType e5 = new FlatType()
            {
                Id = 7,
                Name = "3+1",
                DateCreated = System.DateTime.Now,
                IsActive = true
            };
            list.Add(e5);

            FlatType e6 = new FlatType()
            {
                Id = 8,
                Name = "4+0",
                DateCreated = System.DateTime.Now,
                IsActive = true
            };
            list.Add(e6);

            FlatType e7 = new FlatType()
            {
                Id = 9,
                Name = "4+1",
                DateCreated = System.DateTime.Now,
                IsActive = true
            };
            list.Add(e7);

            return list;

        }
    }
}
