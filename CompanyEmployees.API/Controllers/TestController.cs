using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CompanyEmployees.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        [HttpGet("Public")]
        public IActionResult Public()
        {
            var claims = User.Claims;
            return Ok(new { Message = "Public!", Claims = claims });
        }

        [HttpGet("Private")]
        [Authorize]
        public IActionResult Private()
        {
            var claims = User.Claims;
            return Ok(new { Message = "Authorized!", Claims = claims });
        }
    }
}
