using Microsoft.AspNetCore.Mvc;

namespace CongestionTaxCalculator.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ExternalDataSourceController : ControllerBase
{
    [HttpGet]
    [Route("Test")]
    public void test()
    {

    }
}
