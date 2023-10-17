using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaymentMicroservice.Models;

namespace PaymentMicroservice.Controllers
{
    [Route("api/rest/v1")]
    [ApiController]
    public class PaymentController : ControllerBase
    {

        [HttpPost("payment")]
        public IActionResult Payment(PaymentDetails data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok();
        }


    }
}
