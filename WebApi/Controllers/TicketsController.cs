using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Hosting;

namespace WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class TicketsController : Controller
    {
        private readonly TicketContext _context;

        public TicketsController(TicketContext context, IHostingEnvironment env)
        {
            _context = context;  
        }

        // GET: api/Tickets
        [HttpGet]
        public IEnumerable<TicketItem> GetTickets()
        {
            return _context.TicketItems.AsNoTracking();
        }

        // GET: api/Tickets/5
        [HttpGet("{id}", Name = "GetTickets")]
        public async Task<IActionResult> GetTicket([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ticketItem = await _context.TicketItems.SingleOrDefaultAsync(m => m.Id == id);

            if (ticketItem == null)
            {
                return NotFound();
            }

            return Ok(ticketItem);
        }

        // PUT: api/Tickets/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTicket([FromRoute] int id, [FromBody] TicketItem ticketItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ticketItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(ticketItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TicketItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Tickets
        [HttpPost]
        public async Task<IActionResult> CreateTicket([FromBody] TicketItem ticketItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.TicketItems.Add(ticketItem);
            await _context.SaveChangesAsync();

            // return "Tickets/" + ticketItem.Id
            // return CreatedAtRoute("GetTickets", new { id = ticketItem.Id }, ticketItem);
            return CreatedAtAction("GetTickets", new { id = ticketItem.Id }, ticketItem);
        }

        // DELETE: api/Tickets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTicket([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ticketItem = await _context.TicketItems.SingleOrDefaultAsync(m => m.Id == id);
            if (ticketItem == null)
            {
                return NotFound();
            }

            _context.TicketItems.Remove(ticketItem);
            await _context.SaveChangesAsync();

            return Ok(ticketItem);
        }

        private bool TicketItemExists(int id)
        {
            return _context.TicketItems.Any(e => e.Id == id);
        }
    }
}

/*
 * CRUD
 * Create Read Update Delete
 * Post   Get  Put    Delete
 */