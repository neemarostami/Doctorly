using Doctorly.Domain.Common;
using Doctorly.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doctorly.UnitTests.TestsFacts
{
    public class EmailTests
    {
        [Theory]
        [InlineData("neema.rostami@gmail.com", true)]
        [InlineData("nima.com", false)]
        [InlineData("gmail@di@.gmail.com", false)]
        public void CheckEmailFormatValidation(string email, bool isValid)
        {
            bool isCorrectFormat;
            try
            {
                Email emailObj = new(email);
                isCorrectFormat = true;
            }
            catch (InvalidEmailFormatException)
            {
                isCorrectFormat = false;
            }

            Assert.Equal(isValid, isCorrectFormat);
        }
    }
}
