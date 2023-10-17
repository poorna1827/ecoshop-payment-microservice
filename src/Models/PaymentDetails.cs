using System.ComponentModel.DataAnnotations;

namespace PaymentMicroservice.Models
{
    public class PaymentDetails
    {
        [Required]
        [RegularExpression(@"^[1-9][0-9]{11}$")]
        public string? CreditCardNumber { get; set; }


        [Required]
        [RegularExpression(@"^[1-9][0-9]{2}$")]
        public string? Cvv { get; set; }


        [Required]
        [RegularExpression(@"^(0[1-9]|1[0-2])\/(2[4-9]|[3-9][0-9])$")]
        public string? ExpiryYear { get; set; }
    }
}
