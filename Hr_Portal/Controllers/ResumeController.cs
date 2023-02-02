using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hr_Portal.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Hr_Portal.Controllers
{
    public class ResumeController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public ResumeController(AppDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        // GET: Resume
        public async Task<IActionResult> Index()
        {
              return _context.Resumes != null ? 
                          View(await _context.Resumes.ToListAsync()) :
                          Problem("Entity set 'AppDbContext.Resumes'  is null.");
        }

        // GET: Resume/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Resumes == null)
            {
                return NotFound();
            }

            var resumeModel = await _context.Resumes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (resumeModel == null)
            {
                return NotFound();
            }

            return View(resumeModel);
        }

        // GET: Resume/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Resume/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Email,ContactNo,Dates,Qualification,SkillSet,Experience,Reference,Status,Comments,ResumeFile")] ResumeModel resumeModel)
        {
            if (ModelState.IsValid)
            {
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


                _context.Add(resumeModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(resumeModel);
        }

        // GET: Resume/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Resumes == null)
            {
                return NotFound();
            }

            var resumeModel = await _context.Resumes.FindAsync(id);
            if (resumeModel == null)
            {
                return NotFound();
            }
            return View(resumeModel);
        }

        // POST: Resume/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Email,ContactNo,Dates,Qualification,SkillSet,Experience,Reference,Status,Comments,ResumeName")] ResumeModel resumeModel)
        {
            if (id != resumeModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(resumeModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ResumeModelExists(resumeModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(resumeModel);
        }

        // GET: Resume/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Resumes == null)
            {
                return NotFound();
            }

            var resumeModel = await _context.Resumes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (resumeModel == null)
            {
                return NotFound();
            }

            return View(resumeModel);
        }

        // POST: Resume/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Resumes == null)
            {
                return Problem("Entity set 'AppDbContext.Resumes'  is null.");
            }
            var resumeModel = await _context.Resumes.FindAsync(id);
            if (resumeModel != null)
            {
                // Delete the file from folder 
                var imagePath = Path.Combine(_hostEnvironment.WebRootPath, "Files", resumeModel.ResumeName);
                if (System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);
                }

                _context.Resumes.Remove(resumeModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ResumeModelExists(int id)
        {
          return (_context.Resumes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
