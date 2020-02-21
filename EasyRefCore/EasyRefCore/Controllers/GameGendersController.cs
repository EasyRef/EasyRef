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
    public class GameGendersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public GameGendersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/GameGenders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GameGender>>> GetGameGender()
        {
            return await _context.GameGender.ToListAsync();
        }

        // GET: api/GameGenders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GameGender>> GetGameGender(int id)
        {
            var gameGender = await _context.GameGender.FindAsync(id);

            if (gameGender == null)
            {
                return NotFound();
            }

            return gameGender;
        }

        // PUT: api/GameGenders/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGameGender(int id, GameGender gameGender)
        {
            if (id != gameGender.Id)
            {
                return BadRequest();
            }

            _context.Entry(gameGender).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GameGenderExists(id))
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

        // POST: api/GameGenders
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<GameGender>> PostGameGender(GameGender gameGender)
        {
            _context.GameGender.Add(gameGender);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGameGender", new { id = gameGender.Id }, gameGender);
        }

        // DELETE: api/GameGenders/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GameGender>> DeleteGameGender(int id)
        {
            var gameGender = await _context.GameGender.FindAsync(id);
            if (gameGender == null)
            {
                return NotFound();
            }

            _context.GameGender.Remove(gameGender);
            await _context.SaveChangesAsync();

            return gameGender;
        }

        private bool GameGenderExists(int id)
        {
            return _context.GameGender.Any(e => e.Id == id);
        }
    }
}
