using CarPartsStore.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarPartsStore.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public UserController()
        {
            
        }
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            try { return Ok(); }
            catch { return BadRequest(); }
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetUser(int id)
        {
            try { return Ok(); }
            catch { return BadRequest(); }
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody]User user)
        {
            try { return Ok(); }
            catch { return BadRequest(); }
        }
        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromBody] User user)
        {
            try { return Ok(); }
            catch { return BadRequest(); }
        }
        [HttpPatch("{id:int}")]
        public async Task<IActionResult> DeleteUser([FromBody] User user)
        {
            try { return Ok(); }
            catch { return BadRequest(); }
        }

    }
}
