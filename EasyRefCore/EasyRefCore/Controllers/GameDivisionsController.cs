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
    public class GameDivisionsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public GameDivisionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/GameDivisions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GameDivision>>> GetGameDivison()
        {
            return await _context.GameDivison.Distinct().ToListAsync();
        }

        // GET: api/GameDivisions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GameDivision>> GetGameDivision(int id)
        {
            var gameDivision = await _context.GameDivison.FindAsync(id);

            if (gameDivision == null)
            {
                return NotFound();
            }

            return gameDivision;
        }

        // PUT: api/GameDivisions/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGameDivision(int id, GameDivision gameDivision)
        {
            if (id != gameDivision.Id)
            {
                return BadRequest();
            }

            _context.Entry(gameDivision).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GameDivisionExists(id))
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

        // POST: api/GameDivisions
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<GameDivision>> PostGameDivision(GameDivision gameDivision)
        {
            _context.GameDivison.Add(gameDivision);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGameDivision", new { id = gameDivision.Id }, gameDivision);
        }

        // DELETE: api/GameDivisions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GameDivision>> DeleteGameDivision(int id)
        {
            var gameDivision = await _context.GameDivison.FindAsync(id);
            if (gameDivision == null)
            {
                return NotFound();
            }

            _context.GameDivison.Remove(gameDivision);
            await _context.SaveChangesAsync();

            return gameDivision;
        }

        private bool GameDivisionExists(int id)
        {
            return _context.GameDivison.Any(e => e.Id == id);
        }
    }
}
