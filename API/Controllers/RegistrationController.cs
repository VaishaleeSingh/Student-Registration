using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using RegistrationAPI.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RegistrationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("CorsPolicy")]
    public class RegistrationController : ControllerBase
    {
        private readonly IMongoCollection<Registration> _registrations;

        public RegistrationController(IMongoCollection<Registration> registrations)
        {
            _registrations = registrations;
        }

        [HttpGet]
        public async Task<ActionResult<List<Registration>>> GetRegistrations()
        {
            var results = await _registrations.Find(_ => true).ToListAsync();
            return Ok(results);
        }

        [HttpPost]
        public async Task<ActionResult<Registration>> SaveRegistration([FromBody] Registration registration)
        {
            if (string.IsNullOrEmpty(registration.studentId))
            {
                registration.studentId = MongoDB.Bson.ObjectId.GenerateNewId().ToString();
            }
            await _registrations.InsertOneAsync(registration);
            return Ok(registration);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRegistration(string id, [FromBody] Registration registration)
        {
            var filter = Builders<Registration>.Filter.Eq(r => r.studentId, id);
            var result = await _registrations.ReplaceOneAsync(filter, registration);
            
            if (result.MatchedCount == 0)
            {
                return NotFound(new { Status = "Error", Message = "Registration record not found." });
            }
            
            return Ok(registration);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRegistrationById(string id)
        {
            var filter = Builders<Registration>.Filter.Eq(r => r.studentId, id);
            var result = await _registrations.DeleteOneAsync(filter);
            
            if (result.DeletedCount > 0)
            {
                return Ok(new { Status = "Success", Message = "Registration deleted." });
            }
            return NotFound(new { Status = "Error", Message = "Registration record not found." });
        }
    }
}
