using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hr_Portal.Models;

namespace Hr_Portal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginAPIController : ControllerBase
    {
        private readonly AppDbContext _context;

        public LoginAPIController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/LoginAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LoginModel>>> GetLogins()
        {
          if (_context.Logins == null)
          {
              return NotFound();
          }
            return await _context.Logins.ToListAsync();
        }

        // GET: api/LoginAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LoginModel>> GetLoginModel(int id)
        {
          if (_context.Logins == null)
          {
              return NotFound();
          }
            var loginModel = await _context.Logins.FindAsync(id);

            if (loginModel == null)
            {
                return NotFound();
            }

            return loginModel;
        }

        // PUT: api/LoginAPI/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLoginModel(int id, LoginModel loginModel)
        {
            if (id != loginModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(loginModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoginModelExists(id))
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

        // POST: api/LoginAPI
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LoginModel>> PostLoginModel(LoginModel loginModel)
        {
          if (_context.Logins == null)
          {
              return Problem("Entity set 'AppDbContext.Logins'  is null.");
          }
            _context.Logins.Add(loginModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLoginModel", new { id = loginModel.Id }, loginModel);
        }

        // DELETE: api/LoginAPI/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLoginModel(int id)
        {
            if (_context.Logins == null)
            {
                return NotFound();
            }
            var loginModel = await _context.Logins.FindAsync(id);
            if (loginModel == null)
            {
                return NotFound();
            }

            _context.Logins.Remove(loginModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LoginModelExists(int id)
        {
            return (_context.Logins?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
