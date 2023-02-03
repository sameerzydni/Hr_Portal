﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hr_Portal.Models;
using Microsoft.Extensions.Hosting;

namespace Hr_Portal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResumeAPIController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public ResumeAPIController(AppDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        // GET: api/ResumeAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResumeModel>>> GetResumes()
        {
          if (_context.Resumes == null)
          {
              return NotFound();
          }
            return await _context.Resumes.ToListAsync();
        }

        // GET: api/ResumeAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ResumeModel>> GetResumeModel(int id)
        {
          if (_context.Resumes == null)
          {
              return NotFound();
          }
            var resumeModel = await _context.Resumes.FindAsync(id);

            if (resumeModel == null)
            {
                return NotFound();
            }

            return resumeModel;
        }

        // PUT: api/ResumeAPI/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutResumeModel(int id, ResumeModel resumeModel)
        {
            if (id != resumeModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(resumeModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ResumeModelExists(id))
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

        // POST: api/ResumeAPI
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ResumeModel>> PostResumeModel([FromForm][Bind("Id,FirstName,LastName,Email,ContactNo,Dates,Qualification,SkillSet,Experience,Reference,Status,Comments,ResumeFile")] ResumeModel resumeModel)
        {
          if (_context.Resumes == null)
          {
              return Problem("Entity set 'AppDbContext.Resumes'  is null.");
          }

            //Save the file into wwwrrot/Files
            string wwwRootPath = _hostEnvironment.WebRootPath;
            string fileName = Path.GetFileNameWithoutExtension(resumeModel.ResumeFile.FileName);
            string extension = Path.GetExtension(resumeModel.ResumeFile.FileName);
            resumeModel.ResumeName = fileName = fileName + Guid.NewGuid().ToString().Substring(0, 4) + '_' + DateTime.Now.ToString("dd" + '-' + "MM" + '-' + "yy") + extension;
            string path = Path.Combine(wwwRootPath + "/Files/", fileName);
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                await resumeModel.ResumeFile.CopyToAsync(fileStream);
            }

            resumeModel.Dates = DateTime.Now;
            resumeModel.Status = "Update";

            _context.Resumes.Add(resumeModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetResumeModel", new { id = resumeModel.Id }, resumeModel);
        }

        // DELETE: api/ResumeAPI/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteResumeModel(int id)
        {
            if (_context.Resumes == null)
            {
                return NotFound();
            }
            var resumeModel = await _context.Resumes.FindAsync(id);
            if (resumeModel == null)
            {
                return NotFound();
            }

            _context.Resumes.Remove(resumeModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ResumeModelExists(int id)
        {
            return (_context.Resumes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
