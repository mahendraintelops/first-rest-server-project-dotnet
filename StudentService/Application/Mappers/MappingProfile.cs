using AutoMapper;

using Application.Commands.StudentService;

using Application.Commands.AddressService;

using Application.Responses;
using Core.Entities;

namespace Application.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
          
            CreateMap<Student, StudentResponse>().ReverseMap();
            CreateMap<Student, CreateStudentCommand>().ReverseMap();
            CreateMap<Student, UpdateStudentCommand>().ReverseMap();
          
            CreateMap<Address, AddressResponse>().ReverseMap();
            CreateMap<Address, CreateAddressCommand>().ReverseMap();
            CreateMap<Address, UpdateAddressCommand>().ReverseMap();
          
        }
    }
}
