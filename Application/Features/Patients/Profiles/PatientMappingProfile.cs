using Application.Features.Patients.Commands.Create;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Patients.Profiles
{
    public class PatientMappingProfile : Profile
    {
        public PatientMappingProfile()
        {
            CreateMap<Patient, CreatePatientCommand>().ReverseMap();
            CreateMap<Patient, CreatePatientResponse>().ReverseMap();
        }
    }
}
