﻿using System;
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
    public class GamesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public GamesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Games
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Game>>> GetGame()
        {
            //Test
            return await _context.Game.Include(x => x.GameFieldSize).Include(x => x.GameDivision).Include(x => x.GameAge).Include(x => x.GameGender).Include(x => x.Referee).Include(x => x.SecondReferee).Include(x => x.ThirdReferee).Include(x => x.Coach).AsNoTracking().ToListAsync();
          // return await _context.Game.ToListAsync();
        }

        [HttpGet("Referee/{id}")]
        public async Task<ActionResult<IEnumerable<Game>>> GetGameForReferee(int id)
        {
            var coach = await _context.Referee.Where(x => x.RefereeId == id).SingleAsync();

            return await _context.Game.Include(x => x.GameFieldSize).Include(x => x.GameDivision).Include(x => x.GameAge).Include(x => x.GameGender).Include(x => x.Referee).Include(x => x.SecondReferee).Include(x => x.ThirdReferee).Include(x => x.Coach)
                .Where(x => x.GameFieldSizeId <= coach.FieldSizeId).AsNoTracking().ToListAsync();
            // return await _context.Game.ToListAsync();
        }


        // GET: api/Games/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Game>> GetGame(int id)
        {
            var game = await _context.Game.Include(x => x.GameFieldSize).Include(x => x.GameDivision).Include(x => x.GameAge).Include(x => x.GameGender)
                .Include(x => x.Referee).Include(x => x.SecondReferee).Include(x => x.ThirdReferee).Include(x => x.Coach).Where(x => x.GameId == id).AsNoTracking().SingleOrDefaultAsync();

            if (game == null)
            {
                return NotFound();
            }

            return game;
        }

        // PUT: api/Games/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.

        [HttpPut]
        public async Task<ActionResult<Game>> PutGame(Game game)
        {
          
            _context.Entry(game).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
           
            }

            return CreatedAtAction("GetGame", new { id = game.GameId }, game);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutGame(int id, Game game)
        {
            if (id != game.GameId)
            {
                return BadRequest();
            }

            _context.Entry(game).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GameExists(id))
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

        // POST: api/Games
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Game>> PostGame(Game game)
        {
            _context.Game.Add(game);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGame", new { id = game.GameId }, game);
        }

        // DELETE: api/Games/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Game>> DeleteGame(int id)
        {
            var game = await _context.Game.FindAsync(id);
            if (game == null)
            {
                return NotFound();
            }

            _context.Game.Remove(game);
            await _context.SaveChangesAsync();

            return game;
        }

        private bool GameExists(int id)
        {
            return _context.Game.Any(e => e.GameId == id);
        }
    }
}
