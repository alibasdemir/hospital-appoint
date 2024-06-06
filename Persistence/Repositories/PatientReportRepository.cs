﻿using Core.DataAccess;
using Domain.Entities;
using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    internal class PatientReportRepository : EfRepositoryBase<PatientReport, HospitalAppointDbContext>
    {
        public PatientReportRepository(HospitalAppointDbContext context) : base(context)
        {
        }
    }
}
