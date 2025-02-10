using AutoMapper;
using Company.Employee.API.Model.DTOs.Employee;
using Company.Employee.API.Model.DTOs.Manager;
using Company.Model.Domain;

namespace Company.Employee.API.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            // Employee part
            CreateMap<Company.Model.Domain.Employee, EmployeeDto>()
                    .ForMember(dest => dest.Manager, opt => opt.MapFrom(src => src.Manager));

            CreateMap<CreateEmployeeDto, Company.Model.Domain.Employee>();

            CreateMap<UpdateEmployeeDto, Company.Model.Domain.Employee>();

            // Manager part
            CreateMap<Manager, ManagerDto>();

            CreateMap<CreateManagerDto, Manager>();

            CreateMap<UpdateManagerDto, Manager>();
        }
    }
}
