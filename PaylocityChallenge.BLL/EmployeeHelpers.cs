using System;
using System.Collections.Generic;
using System.Text;

namespace PaylocityChallenge.BLL
{
    public static class EmployeeHelpers
    {
        // This is very simplistic and would not work in many scenarios. Would need to make a more dynamic solution.
        // I have some things in mind. Let's discuss.
        public static decimal CalculateCostOfBenefits(int numberOfDependents, string firstName)
        {
            decimal cost = 1000m / 26 + 500m * numberOfDependents / 26;
            if (firstName.ToUpper().StartsWith("A"))
            {
                cost -= cost * 0.1m;
            }
            return Math.Round(cost, 2);
        }
    }
}
