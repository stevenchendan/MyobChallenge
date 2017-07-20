using MyobChallenge.Core.Implementation;
using MyobChallenge.Core.Models;
using NUnit.Framework;

namespace MyobChallenge.Tests
{
    [TestFixture]
    public class InputValidatorTests
    {
        private InputValidator _inputValidator;

        [SetUp]
        public void SetUp()
        {
            _inputValidator = new InputValidator();
        }

        [TestCase(-1)]
        [TestCase(51)]
        [TestCase(111)]
        public void Validate_WrongSuper_ReturnFalse(int super)
        {
            var input = new Input
            {
                Super = super
            };

            var result = _inputValidator.Validate(input);
            Assert.IsFalse(result);
        }
        
        [Test]
        public void Validate_NegativeSalary_ReturnFalse()
        {
            var input = new Input
            {
                Super = 10,
                Salary = -1
            };

            var result = _inputValidator.Validate(input);
            Assert.IsFalse(result);
        }
        
        [Test]
        public void Validate_EmptyFirstName_ReturnFalse()
        {
            var input = new Input
            {
                Super = 10,
                Salary = 1000,
                FirstName = "",
                LastName = "Name"
            };

            var result = _inputValidator.Validate(input);
            Assert.IsFalse(result);
        }
        
        [Test]
        public void Validate_EmptyLastName_ReturnFalse()
        {
            var input = new Input
            {
                Super = 10,
                Salary = 1000,
                FirstName = "Name",
                LastName = null
            };

            var result = _inputValidator.Validate(input);
            Assert.IsFalse(result);
        }
        
        [Test]
        public void Validate_WrongPeriodParts_ReturnFalse()
        {
            var input = new Input
            {
                Super = 10,
                Period = "March 1",
                Salary = 1000,
                FirstName = "Name",
                LastName = "LastName"
            };

            var result = _inputValidator.Validate(input);
            Assert.IsFalse(result);
        }
        
        [Test]
        public void Validate_WrongPeriodStartPart_ReturnFalse()
        {
            var input = new Input
            {
                Super = 10,
                Period = "March - 1 March",
                Salary = 1000,
                FirstName = "Name",
                LastName = "LastName"
            };

            var result = _inputValidator.Validate(input);
            Assert.IsFalse(result);
        }
        
        [Test]
        public void Validate_WrongPeriodEndPart_ReturnFalse()
        {
            var input = new Input
            {
                Super = 10,
                Period = "1 March - March",
                Salary = 1000,
                FirstName = "Name",
                LastName = "LastName"
            };

            var result = _inputValidator.Validate(input);
            Assert.IsFalse(result);
        }
        
        [Test]
        public void Validate_Differentmonths_ReturnFalse()
        {
            var input = new Input
            {
                Super = 10,
                Period = "1 March - 31 April",
                Salary = 1000,
                FirstName = "Name",
                LastName = "LastName"
            };

            var result = _inputValidator.Validate(input);
            Assert.IsFalse(result);
        }
        
        [Test]
        public void Validate_WrongStartDay_ReturnFalse()
        {
            var input = new Input
            {
                Super = 10,
                Period = "11 March - 31 March",
                Salary = 1000,
                FirstName = "Name",
                LastName = "LastName"
            };

            var result = _inputValidator.Validate(input);
            Assert.IsFalse(result);
        }
        
        [Test]
        public void Validate_UnknownMonth_ReturnFalse()
        {
            var input = new Input
            {
                Super = 10,
                Period = "11 March1 - 31 March1",
                Salary = 1000,
                FirstName = "Name",
                LastName = "LastName"
            };

            var result = _inputValidator.Validate(input);
            Assert.IsFalse(result);
        }
        
        [Test]
        public void Validate_WrongEndDay_ReturnFalse()
        {
            var input = new Input
            {
                Super = 10,
                Period = "1 March - 30 March",
                Salary = 1000,
                FirstName = "Name",
                LastName = "LastName"
            };

            var result = _inputValidator.Validate(input);
            Assert.IsFalse(result);
        }
        
        [Test]
        public void Validate_CorrectInput_ReturnTrue()
        {
            var input = new Input
            {
                Super = 10,
                Period = "1 March - 31 March",
                Salary = 10000,
                FirstName = "Name",
                LastName = "Name2"
            };

            var result = _inputValidator.Validate(input);
            Assert.IsTrue(result);
        }
    }
}
