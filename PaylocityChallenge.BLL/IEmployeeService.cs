using PaylocityChallenge.Objects;
using System.Collections.Generic;

namespace PaylocityChallenge.BLL
{
    public interface IEmployeeService
    {
        IList<EmployeeDTO> GetAll();
        EmployeeDTO GetById(int id);
        EmployeeDTO Add(EmployeeDTO employee);
        void Update(EmployeeDTO employee);
    }
}
