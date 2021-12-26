using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieWebApp_ASP.NET.Models;
using OdevSonHali.Data;

namespace OdevSonHali.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiLikedsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ApiLikedsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ApiLikeds
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Liked>>> GetLiked()
        {
            return await _context.Liked.ToListAsync();
        }

        // GET: api/ApiLikeds/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Liked>> GetLiked(int id)
        {
            var liked = await _context.Liked.FindAsync(id);

            if (liked == null)
            {
                return NotFound();
            }

            return liked;
        }

        // PUT: api/ApiLikeds/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLiked(int id, Liked liked)
        {
            if (id != liked.Id)
            {
                return BadRequest();
            }

            _context.Entry(liked).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LikedExists(id))
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

        // POST: api/ApiLikeds
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Liked>> PostLiked(Liked liked)
        {
            _context.Liked.Add(liked);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLiked", new { id = liked.Id }, liked);
        }

        // DELETE: api/ApiLikeds/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLiked(int id)
        {
            var liked = await _context.Liked.FindAsync(id);
            if (liked == null)
            {
                return NotFound();
            }

            _context.Liked.Remove(liked);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LikedExists(int id)
        {
            return _context.Liked.Any(e => e.Id == id);
        }
    }
}
