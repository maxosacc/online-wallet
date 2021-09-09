using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppServer.Controllers
{
    [Route("[controller]")]
    public class HealthController : ControllerBase
    {
        [Route("Check")]
        public IActionResult Check()
        {
            return Ok(new
            {
                Status = "Active"
            });
        }
    }
}
