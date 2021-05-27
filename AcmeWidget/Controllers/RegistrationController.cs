using AcmeWidget.Interface;
using AcmeWidget.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcmeWidget.Controllers
{
    [ApiController]
    [Route("api")]
    public class RegistrationController : ControllerBase
    {

        IRegistraionService _svcRegistration;
        private readonly ILogger<RegistrationController> _logger;

        public RegistrationController(ILogger<RegistrationController> logger, IRegistraionService svcRegistration)
        {
            _logger = logger;
            _svcRegistration = svcRegistration;
        }


        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> RegisterContact([FromBody] Contact Data)
        {
            var response = await _svcRegistration.RegisterContact(Data);
            return Ok(response);
        }


    }
}
