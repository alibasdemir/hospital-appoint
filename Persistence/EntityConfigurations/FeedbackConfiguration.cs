using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations
{
    public class FeedbackConfiguration : IEntityTypeConfiguration<Feedback>
    {
        public void Configure(EntityTypeBuilder<Feedback> builder)
        {

            Feedback[] feedbackSeeds =
            {
                new Feedback
                {
                    Id = 1,
                    Title = "Test",
                    Description = "Test",
                    Rating = 10,
                    UserId = 1,
                },
                new Feedback
                {
                    Id = 2,
                    Title = "Test2",
                    Description = "Test2",
                    Rating = 9,
                    UserId = 1,
                },
                new Feedback
                {
                    Id = 3,
                    Title = "Test3",
                    Description = "Test3",
                    Rating = 7,
                    UserId = 2,
                },
                new Feedback
                {
                    Id = 4,
                    Title = "Test4",
                    Description = "Test4",
                    Rating = 5,
                    UserId = 3,
                },
            };
            builder.HasData(feedbackSeeds);
        }
    }
}
