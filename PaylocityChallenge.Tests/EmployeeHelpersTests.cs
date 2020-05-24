using Xunit;
using PaylocityChallenge.BLL;

namespace PaylocityChallenge.Tests
{
    public class EmployeeHelpersTests
    {
        [Fact]
        public void CalculateCostOfBenefits_Should_Return_Cost_When_0_Dependents()
        {
            // Arrange
            decimal expectedResult = 38.46m;

            // Act
            var result = EmployeeHelpers.CalculateCostOfBenefits(0, "TestGuy");

            //Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void CalculateCostOfBenefits_Should_Return_Cost_When_0_Dependents_With_First_Letter_A()
        {
            // Arrange
            decimal expectedResult = 34.62m;

            // Act
            var result = EmployeeHelpers.CalculateCostOfBenefits(0, "ATestGuy");

            //Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void CalculateCostOfBenefits_Should_Return_Cost_When_2_Dependents()
        {
            // Arrange
            decimal expectedResult = 76.92m;

            // Act
            var result = EmployeeHelpers.CalculateCostOfBenefits(2, "TestGuy");

            //Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void CalculateCostOfBenefits_Should_Return_Cost_When_2_Dependents_With_First_Letter_A()
        {
            // Arrange
            decimal expectedResult = 69.23m;

            // Act
            var result = EmployeeHelpers.CalculateCostOfBenefits(2, "ATestGuy");

            //Assert
            Assert.Equal(expectedResult, result);
        }
    }
}
