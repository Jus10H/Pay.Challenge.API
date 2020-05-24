using PaylocityChallenge.DLL.Entities;
using PaylocityChallenge.Objects;

namespace PaylocityChallenge.Tests.Mocks
{
    public class EmployeeMock
    {
        public EmployeeMock()
        {
            Employee = new Employee
            {
                FirstName = "TestGuy",
                LastName = "TestLastName",
                NumberOfDependents = 2
            };

            EmployeeDTO = new EmployeeDTO
            {
                FirstName = "TestGuy",
                LastName = "TestLastName",
                NumberOfDependents = 2,
                BenefitsCost = 0
            };
        }
        public Employee Employee { get; set; }
        public EmployeeDTO EmployeeDTO { get; set; }
    }
}
