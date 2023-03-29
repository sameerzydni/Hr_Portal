using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hr_Portal.Models;
using Microsoft.AspNetCore.Authorization;

namespace Hr_Portal.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class JavaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public JavaController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Java
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JavaQuestion>>> GetJavaQuestions()
        {
          if (_context.JavaQuestions == null)
          {
              return NotFound();
          }
            var Random5Qns = await (_context.JavaQuestions
                        .Select(x => new
                        {
                            QnId = x.QnId,
                            QnInWord = x.QnInWords,
                            ImageName = x.ImageName,
                            Options = new string[] { x.Option1, x.Option2, x.Option3, x.Option4 },
                            Answer = x.Answer
                        })
                        .OrderBy(y => Guid.NewGuid())
                        .Take(30)
                        ).ToListAsync();
            return Ok(Random5Qns);
            //return await _context.JavaQuestions.ToListAsync();
        }

        // GET: api/Java/5
        [HttpGet("{id}")]
        public async Task<ActionResult<JavaQuestion>> GetJavaQuestion(int id)
        {
          if (_context.JavaQuestions == null)
          {
              return NotFound();
          }
            var javaQuestion = await _context.JavaQuestions.FindAsync(id);

            if (javaQuestion == null)
            {
                return NotFound();
            }

            return javaQuestion;
        }

        //// PUT: api/Java/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutJavaQuestion(int id, JavaQuestion javaQuestion)
        //{
        //    if (id != javaQuestion.QnId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(javaQuestion).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!JavaQuestionExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/Java
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<JavaQuestion>> PostJavaQuestion(JavaQuestion javaQuestion)
        //{
        //  if (_context.JavaQuestions == null)
        //  {
        //      return Problem("Entity set 'AppDbContext.JavaQuestions'  is null.");
        //  }
        //    _context.JavaQuestions.Add(javaQuestion);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetJavaQuestion", new { id = javaQuestion.QnId }, javaQuestion);
        //}

        //// DELETE: api/Java/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteJavaQuestion(int id)
        //{
        //    if (_context.JavaQuestions == null)
        //    {
        //        return NotFound();
        //    }
        //    var javaQuestion = await _context.JavaQuestions.FindAsync(id);
        //    if (javaQuestion == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.JavaQuestions.Remove(javaQuestion);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        private bool JavaQuestionExists(int id)
        {
            return (_context.JavaQuestions?.Any(e => e.QnId == id)).GetValueOrDefault();
        }
    }
}
