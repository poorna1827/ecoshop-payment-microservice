

using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using PaymentMicroservice.Controllers;
using PaymentMicroservice.Models;
using System.ComponentModel.DataAnnotations;
using Xunit;

namespace tests.Systems.Controllers
{
    public class TestPaymentController
    {

        [Fact]
        public void Payment_ShouldReturn404Status()
        {
            //Arrange

            PaymentDetails data = new PaymentDetails()
            {
                CreditCardNumber = "123456789123",
                Cvv = "123",
                ExpiryYear = "05/25"

            };
            var sut = new PaymentController();

            //Act 

            var result =  sut.Payment(data);

            //Assert

            result.GetType().Should().Be(typeof(OkResult));
        }


    }
}
