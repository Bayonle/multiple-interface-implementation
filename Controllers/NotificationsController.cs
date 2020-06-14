using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using multiple_interface_implementation.Config;
using multiple_interface_implementation.Controllers.Interfaces;
using multiple_interface_implementation.Dtos;

namespace multiple_interface_implementation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotificationsController : ControllerBase
    {
        public readonly IEnumerable<IEmailSender> _emailSender;
        public readonly IOptionsSnapshot<EmailSettings> _options;

        public NotificationsController(
            IEnumerable<IEmailSender> emailSender,
            IOptionsSnapshot<EmailSettings> options)
        {
            _emailSender = emailSender;
            _options = options;
        }

        [HttpPost]
        public IActionResult Post([FromBody]NewEmailDto email)
        {
            var emailSettings = _options.Value;
            IEmailSender service = _emailSender.FirstOrDefault(x => x.providerName == emailSettings.ActiveProviderName);

            service.sendEmail(email.EmailAddress, email.Message);

            return Ok(nameof(service));
        }
    }
}