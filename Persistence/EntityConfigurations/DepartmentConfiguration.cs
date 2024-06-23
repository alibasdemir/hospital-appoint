using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            Department[] departmentSeeds =
            {
                new Department
                {
                    Id = 1,
                    Name = "Cardiology",
                    Description = "Deals with diseases of the heart and circulatory system. Treats conditions like heart attacks, hypertension, cardiac rhythm disorders."
                },
                new Department
                {
                    Id = 2,
                    Name = "Neurology",
                    Description = "Deals with diseases of the nervous system. Treats disorders related to the brain, spinal cord, nerves, and muscles."
                },
                new Department 
                {
                    Id = 3,
                    Name = "Orthopedics and Traumatology",
                    Description = "Focuses on bones, joints, muscles, and connective tissues. Treats conditions such as fractures, dislocations, sports injuries."
                }
            };
            builder.HasData(departmentSeeds);
        }
    }
}
