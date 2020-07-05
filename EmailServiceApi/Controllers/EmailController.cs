using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmailServiceApi.Interfaces;
using EmailServiceApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmailServiceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailServices _emailService;
        public EmailController(IEmailServices emailService)
        {
            _emailService = emailService;
        }

        
        [HttpPost]
        public async Task<ActionResult> SendEmail([FromBody] EmailModel m)
        {
            
            await _emailService.SendEmail(m.To, m.Cc, m.Subject, m.Message);

            return Ok();
        }

    }
}
