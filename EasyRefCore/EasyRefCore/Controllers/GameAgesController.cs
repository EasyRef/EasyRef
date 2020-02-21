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
    public class GameAgesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public GameAgesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/GameAges
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GameAge>>> GetGameAge()
        {
            return await _context.GameAge.ToListAsync();
        }

        // GET: api/GameAges/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GameAge>> GetGameAge(int id)
        {
            var gameAge = await _context.GameAge.FindAsync(id);

            if (gameAge == null)
            {
                return NotFound();
            }

            return gameAge;
        }

        // PUT: api/GameAges/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGameAge(int id, GameAge gameAge)
        {
            if (id != gameAge.Id)
            {
                return BadRequest();
            }

            _context.Entry(gameAge).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GameAgeExists(id))
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

        // POST: api/GameAges
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<GameAge>> PostGameAge(GameAge gameAge)
        {
            _context.GameAge.Add(gameAge);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGameAge", new { id = gameAge.Id }, gameAge);
        }

        // DELETE: api/GameAges/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GameAge>> DeleteGameAge(int id)
        {
            var gameAge = await _context.GameAge.FindAsync(id);
            if (gameAge == null)
            {
                return NotFound();
            }

            _context.GameAge.Remove(gameAge);
            await _context.SaveChangesAsync();

            return gameAge;
        }

        private bool GameAgeExists(int id)
        {
            return _context.GameAge.Any(e => e.Id == id);
        }
    }
}
