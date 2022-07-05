using Microsoft.AspNetCore.Mvc;

namespace SampleECommerce.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ErrorController : ControllerBase
    {
        //This action method handles all unhandled exceptions in non-develpment environments
        //by hiding all the internal details of the exception from consumer
        [Route("")]
        public IActionResult HandleError() => Problem("There is some problem. Please try after some time.");
    }
}
