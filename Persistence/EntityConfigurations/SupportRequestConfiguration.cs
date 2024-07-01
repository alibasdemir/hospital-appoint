using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations
{
    public class SupportRequestConfiguration : IEntityTypeConfiguration<SupportRequest>
    {
        public void Configure(EntityTypeBuilder<SupportRequest> builder)
        {
            SupportRequest[] supportRequestSeeds =
            {
                new SupportRequest
                {
                    Id = 1,
                    FirstName = "Lorem",
                    LastName = "Ipsum",
                    Email = "loremipsum@loremipsum.com",
                    PhoneNumber = "1234567890",
                    Title = "Title",
                    Content = "Content"
                },
                new SupportRequest
                {
                    Id = 2,
                    FirstName = "Lorem2",
                    LastName = "Ipsum2",
                    Email = "loremipsum2@loremipsum2.com",
                    PhoneNumber = "1234567890",
                    Title = "Title2",
                    Content = "Content2"
                },
            };
            builder.HasData(supportRequestSeeds);
        }
    }
}
