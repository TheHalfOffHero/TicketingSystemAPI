using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketingSystemAPI.Models;
using TicketingSystemAPI.Repositories;
using TicketingSystemAPI.Repositories.Implementations;

namespace TicketingSystemAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly TicketRepository _ticketRepository = new TicketRepository(new TicketingSystemApiContext());
        
        // GET: api/<TicketController>
        [HttpGet]
        public IActionResult GetTickets()
        {
            var tickets = _ticketRepository.GetAllTickets();
            if (tickets == null)
            {
                return NotFound();
            }

            return Ok(tickets);
        }

        // GET api/<TicketController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ticket>> GetTicket(int id)
        {
            var ticket = _ticketRepository.GetTicketById(id);

            if (ticket == null)
            {
                return NotFound();
            }

            return Ok(ticket);
        }

        // POST api/<TicketController>
        [HttpPost]
        public IActionResult PostTicket(Ticket ticket)
        {
            var a = _ticketRepository.CreateTicket(ticket);

            if (a < 0)
            {
                return BadRequest(ticket);
            }

            return Ok($"Added ticket with id {a}");
        }

        // PUT api/<TicketController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TicketController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
