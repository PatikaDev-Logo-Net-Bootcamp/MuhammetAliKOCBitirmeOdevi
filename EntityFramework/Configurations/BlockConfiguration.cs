using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace EntityFramework.Context.Configurations
{
    public class BlockConfiguration : IEntityTypeConfiguration<Block>
    {
        public void Configure(EntityTypeBuilder<Block> builder)
        {
            builder.ToTable("Blocks");
            builder.HasKey(x => x.Id);

            builder.HasData(Seed());

        }

        /*Uygulama ilk ayağa kaltığında tabloda olmasını istediğim verileri burada belirliyoruz.*/
        private List<Block> Seed()
        {
            var list = new List<Block>();
            Block e1 = new Block()
            {
                Id = 1,
                Name = "Tanımsız",
                DateCreated = System.DateTime.Now,
                IsActive = true
            };
            list.Add(e1);

        

            return list;

        }
    }
}
