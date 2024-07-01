using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Enums;

namespace Persistence.EntityConfigurations
{
    public class NotificationConfiguration : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            Notification[] notificationSeeds =
            {
                new Notification
                {
                    Id = 1,
                    NotificationType = NotificationType.Email,
                    Title = "Test",
                    Message = "Test",
                    SentAt = new DateTime(2024, 06, 30, 13, 0, 0)
                },
            };
            builder.HasData(notificationSeeds);
        }
    }
}
