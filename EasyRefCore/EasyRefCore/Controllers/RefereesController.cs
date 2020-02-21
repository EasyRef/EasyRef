using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EasyRefCore.Data;
using EasyRefCore.Models;

namespace EasyRefCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RefereesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public RefereesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Referees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Referee>>> GetReferee()
        {
            return await _context.Referee.Include(x => x.FieldSize).ToListAsync();
        }

        // GET: api/Referees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Referee>> GetReferee(int id)
        {
            var referee = await _context.Referee.FindAsync(id);

            if (referee == null)
            {
                return NotFound();
            }

            return referee;
        }

        // PUT: api/Referees/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReferee(int id, Referee referee)
        {
            if (id != referee.RefereeId)
            {
                return BadRequest();
            }

            _context.Entry(referee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RefereeExists(id))
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

        // POST: api/Referees
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Referee>> PostReferee(Referee referee)
        {
            _context.Referee.Add(referee);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReferee", new { id = referee.RefereeId }, referee);
        }

        // DELETE: api/Referees/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Referee>> DeleteReferee(int id)
        {
            var referee = await _context.Referee.FindAsync(id);
            if (referee == null)
            {
                return NotFound();
            }

            _context.Referee.Remove(referee);
            await _context.SaveChangesAsync();

            return referee;
        }

        private bool RefereeExists(int id)
        {
            return _context.Referee.Any(e => e.RefereeId == id);
        }
    }
}
