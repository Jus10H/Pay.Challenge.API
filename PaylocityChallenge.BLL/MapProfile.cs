using AutoMapper;
using PaylocityChallenge.DLL.Entities;
using PaylocityChallenge.Objects;

namespace PaylocityChallenge.BLL
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Employee, EmployeeDTO>();
            CreateMap<EmployeeDTO, Employee>();
        }
    }
}
