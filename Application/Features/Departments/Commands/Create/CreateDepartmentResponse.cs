using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Departments.Commands.Create
{
    public class CreateDepartmentResponse
    {
        public string DepartmentName { get; set; }
        public string DepartmentDescription { get; set; }
    }
}
