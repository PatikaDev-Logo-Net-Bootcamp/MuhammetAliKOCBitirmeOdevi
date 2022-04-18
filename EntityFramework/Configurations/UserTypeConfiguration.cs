using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace EntityFramework.Context.Configurations
{
    public class UserTypeConfiguration : IEntityTypeConfiguration<UserType>
    {
        public void Configure(EntityTypeBuilder<UserType> builder)
        {
            builder.ToTable("UserTypes");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired();

            builder.HasData(Seed());

        }

        /*Uygulama ilk ayağa kaltığında tabloda olmasını istediğim verileri burada belirliyoruz.*/
        private List<UserType> Seed()
        {
            var list = new List<UserType>();
            UserType e1 = new UserType()
            {
                Id = 1,
                Name = "Daire Sahibi",
                DateCreated = System.DateTime.Now,
                IsActive = true
            };
            list.Add(e1);

            UserType e2 = new UserType()
            {
                Id = 2,
                Name = "Kiracı",
                DateCreated = System.DateTime.Now,
                IsActive = true
            };
            list.Add(e2); 
            
            UserType e3 = new UserType()
            {
                Id = 3,
                Name = "Apartman Görevlisi",
                DateCreated = System.DateTime.Now,
                IsActive = true
            };
            list.Add(e3);


            return list;

        }
    }
}
