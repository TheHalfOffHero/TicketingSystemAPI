using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TicketingSystemAPI.Models;
using TicketingSystemAPI.Repositories.Implementations;

namespace TicketingSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserRepository _userRepository = new UserRepository(new TicketingSystemApiContext());

        // GET: api/User
        [HttpGet]
        public IActionResult GetUsers()
        {
            var a = _userRepository.GetAllUsers();
            if (a == null)
            {
                return NotFound();
            }

            return Ok(a);
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var a = _userRepository.GetUserById(id);
        
            if (a == null)
            {
                return NotFound();
            }
        
            return Ok(a);
        }

        // PUT: api/User/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            var a = _userRepository.UpdateUser(user);

            if (a < 0)
            {
                return BadRequest(a);
            }
            
            return Ok($"Updated the the user {user.UserName}");
        }

        // POST: api/User
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IActionResult PostUser(User user)
        {
            var a = _userRepository.CreateUser(user);
            if (a < 0 )
            {
                return BadRequest(a);
            }

            return Ok($"Added user with id: {a}");
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var a = _userRepository.DeleteUser(id);

            if (a < 0)
            {
                return BadRequest(a);
            }

            return Ok($"Deleted the user {a}");
        }
        
    }
}
