using AutoMapper;
using PaylocityChallenge.DLL;
using PaylocityChallenge.DLL.Entities;
using System.Collections.Generic;
using PaylocityChallenge.Objects;
using System.Linq;

namespace PaylocityChallenge.BLL
{
    public class EmployeeService: IEmployeeService
    {
        private readonly IRepository<Employee> _repository;
        private readonly IMapper _mapper;

        public EmployeeService(IRepository<Employee> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IList<EmployeeDTO> GetAll()
        {
            var result = _repository.GetAll()
                            .Select(emp => new EmployeeDTO
                            {
                                Id = emp.Id,
                                FirstName = emp.FirstName,
                                LastName = emp.LastName,
                                NumberOfDependents = emp.NumberOfDependents,
                                BenefitsCost = EmployeeHelpers.CalculateCostOfBenefits(emp.NumberOfDependents, emp.FirstName)
                            }).ToList();

            return result;
        }

        public EmployeeDTO GetById(int id)
        {
            var result = _repository.GetById(id);
            if (result != null)
            {
                return _mapper.Map<Employee, EmployeeDTO>(result);
            }
            return null;
        }

        public EmployeeDTO Add(EmployeeDTO employee)
        {
            var result = _repository.Add(_mapper.Map<EmployeeDTO, Employee>(employee));
            if (result != null)
            {
                return _mapper.Map<Employee, EmployeeDTO>(result);
            }
            return null;
        }

        public void Update(EmployeeDTO employee)
        {
            _repository.Update(_mapper.Map<Employee>(employee));
        }        
    }
}
