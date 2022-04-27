using Microsoft.AspNetCore.Mvc;
using System;

namespace CommandService.Controllers
{
    [Route("api/c/[controller]")]
    [ApiController]
    public class PlatformsController: ControllerBase
    {
        [HttpPost]
        public IActionResult TestInboundConnection(){

            Console.WriteLine("Inbound post # Command Service");
            return Ok("Inbound test from Platforms controller of Command Service");
        }
    }
}