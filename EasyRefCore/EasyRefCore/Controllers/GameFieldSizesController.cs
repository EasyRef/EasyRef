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
    public class GameFieldSizesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public GameFieldSizesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/GameFieldSizes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GameFieldSize>>> GetGameFieldSize()
        {
            return await _context.GameFieldSize.Distinct().ToListAsync();
        }

        // GET: api/GameFieldSizes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GameFieldSize>> GetGameFieldSize(int id)
        {
            var gameFieldSize = await _context.GameFieldSize.FindAsync(id);

            if (gameFieldSize == null)
            {
                return NotFound();
            }

            return gameFieldSize;
        }

        // PUT: api/GameFieldSizes/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGameFieldSize(int id, GameFieldSize gameFieldSize)
        {
            if (id != gameFieldSize.Id)
            {
                return BadRequest();
            }

            _context.Entry(gameFieldSize).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GameFieldSizeExists(id))
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

        // POST: api/GameFieldSizes
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<GameFieldSize>> PostGameFieldSize(GameFieldSize gameFieldSize)
        {
            _context.GameFieldSize.Add(gameFieldSize);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGameFieldSize", new { id = gameFieldSize.Id }, gameFieldSize);
        }

        // DELETE: api/GameFieldSizes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GameFieldSize>> DeleteGameFieldSize(int id)
        {
            var gameFieldSize = await _context.GameFieldSize.FindAsync(id);
            if (gameFieldSize == null)
            {
                return NotFound();
            }

            _context.GameFieldSize.Remove(gameFieldSize);
            await _context.SaveChangesAsync();

            return gameFieldSize;
        }

        private bool GameFieldSizeExists(int id)
        {
            return _context.GameFieldSize.Any(e => e.Id == id);
        }
    }
}
