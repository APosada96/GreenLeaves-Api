using GreenLeaves.Domain.Models;
using GreenLeaves.Domain.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace GreenLeaves.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;
        public ContactController(IContactService contactService)
        {
            _contactService = contactService ?? throw new ArgumentNullException(nameof(contactService));
        }

        /// <summary>
        /// Get Cyty and state
        /// </summary>
        /// <returns>Ok Status Code</returns>
        [HttpGet("[action]")]
        [ProducesResponseType(typeof(Contact), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [SwaggerOperation(Tags = new[] { "Permission: GetCityAndState", "Path: Contact" })]
        public async Task<IActionResult> GetCytyAndState()
        {

            try
            {
                return Ok(await _contactService.GetCityAndState());
            }
            catch (Exception ex)
            {
                return NotFound($"Error : {HttpStatusCode.NotFound}, {ex.Message}");
            }
        }

        /// <summary>
        /// SendEmail
        /// </summary>
        /// <returns>Ok Status Code</returns>
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(Contact), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [SwaggerOperation(Tags = new[] { "Permission: SendEmail", "Path: Contact" })]
        public async Task<IActionResult> SendEmail([FromBody] ContactViewModel contact)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                var result = await _contactService.SendMessage(contact);
                return Ok();    
            }
            catch (Exception ex)
            {
                return NotFound($"Error : {HttpStatusCode.NotFound}, {ex.Message}");
            }
        }
    }
}
