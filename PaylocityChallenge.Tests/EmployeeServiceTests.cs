using Xunit;
using Moq;
using PaylocityChallenge.BLL;
using PaylocityChallenge.DLL;
using PaylocityChallenge.DLL.Entities;
using AutoMapper;
using PaylocityChallenge.Tests.Mocks;
using PaylocityChallenge.Objects;

namespace PaylocityChallenge.Tests
{
    public class EmployeeServiceTests
    {       
        [Fact]
        public void GetById_Should_Return_EmployeeDTO()
        {
            // Arrange
            var expectedResult = new EmployeeMock().EmployeeDTO;

            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(x => x.Map<Employee, EmployeeDTO>(It.IsAny<Employee>()))
                .Returns(expectedResult);

            var repoMock = new Mock<IRepository<Employee>>();
            repoMock.Setup(x => x.GetById(It.IsAny<int>())).Returns(new EmployeeMock().Employee);

            var employeeService = new EmployeeService(repoMock.Object, mapperMock.Object);

            // Act
            var result = employeeService.GetById(128);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void GetById_Should_Return_Null()
        {
            // Arrange
            var mapperMock = new Mock<IMapper>();
            Employee employeeResult = null;

            var repoMock = new Mock<IRepository<Employee>>();
            repoMock.Setup(x => x.GetById(It.IsAny<int>())).Returns(employeeResult);

            var employeeService = new EmployeeService(repoMock.Object, mapperMock.Object);

            // Act
            var result = employeeService.GetById(3);

            // Assert
            Assert.Null(result);
        }
    }
}
