using FluentAssertions;
using PaymentMicroservice.Models;
using System.ComponentModel.DataAnnotations;

using Xunit;

namespace tests.Systems.Models
{
    public class TestPaymentDetails
    {

        [Fact]
        public void For_Valid_Details()
        {
            //Arrange

            PaymentDetails data = new PaymentDetails()
            {
                CreditCardNumber = "123456789123",
                Cvv = "123",
                ExpiryYear = "05/25"

            };
            var context = new ValidationContext(data, null, null); // Create a validation context
            var results = new List<ValidationResult>(); // Create a list to hold the validation results



            //Act
            var isValid = Validator.TryValidateObject(data, context, results, true); // Validate the model



            //Assert
            isValid.Should().BeTrue(); // The model should be invalid
            results.Should().BeEmpty(); // There should be at least one validation error


        }

        [Fact]
        public void For_All_Invalid_Details()
        {
            //Arrange

            PaymentDetails data = new PaymentDetails();
            var context = new ValidationContext(data, null, null); // Create a validation context
            var results = new List<ValidationResult>(); // Create a list to hold the validation results



            //Act
            var isValid = Validator.TryValidateObject(data, context, results, true); // Validate the model



            //Assert
            isValid.Should().BeFalse(); // The model should be invalid
            results.Should().HaveCount(3);


        }

        [Fact]
        public void For_Invalid_CreditCardNumber()
        {
            //Arrange

            PaymentDetails data = new PaymentDetails()
            {
                CreditCardNumber = "1234567891234",
                Cvv = "123",
                ExpiryYear = "05/25"

            };
            var context = new ValidationContext(data, null, null); // Create a validation context
            var results = new List<ValidationResult>(); // Create a list to hold the validation results



            //Act
            var isValid = Validator.TryValidateObject(data, context, results, true); // Validate the model



            //Assert
            isValid.Should().BeFalse(); // The model should be invalid
            results.Should().HaveCount(1);
            results.Single().MemberNames.Should().Contain("CreditCardNumber");
            results.Single().ErrorMessage.Should().Contain("The field CreditCardNumber must match the regular expression '^[1-9][0-9]{11}$'.");


        }

        [Fact]
        public void For_Invalid_Cvv()
        {
            //Arrange

            PaymentDetails data = new PaymentDetails()
            {
                CreditCardNumber = "123456789123",
                Cvv = "1239",
                ExpiryYear = "05/25"

            };
            var context = new ValidationContext(data, null, null); // Create a validation context
            var results = new List<ValidationResult>(); // Create a list to hold the validation results



            //Act
            var isValid = Validator.TryValidateObject(data, context, results, true); // Validate the model



            //Assert
            isValid.Should().BeFalse(); // The model should be invalid
            results.Should().HaveCount(1);
            results.Single().MemberNames.Should().Contain("Cvv");
            results.Single().ErrorMessage.Should().Contain("The field Cvv must match the regular expression '^[1-9][0-9]{2}$'.");
        }

        [Fact]
        public void For_Invalid_ExpiryYear()
        {
            //Arrange

            PaymentDetails data = new PaymentDetails()
            {
                CreditCardNumber = "123456789123",
                Cvv = "123",
                ExpiryYear = "05/21"

            };
            var context = new ValidationContext(data, null, null); // Create a validation context
            var results = new List<ValidationResult>(); // Create a list to hold the validation results



            //Act
            var isValid = Validator.TryValidateObject(data, context, results, true); // Validate the model



            //Assert
            isValid.Should().BeFalse(); // The model should be invalid
            results.Should().HaveCount(1);
            results.Single().MemberNames.Should().Contain("ExpiryYear");
            results.Single().ErrorMessage.Should().Contain("The field ExpiryYear must match the regular expression '^(0[1-9]|1[0-2])\\/(2[4-9]|[3-9][0-9])$'.");
        }
    }
}
