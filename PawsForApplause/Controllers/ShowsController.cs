using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PawsForApplause.Data;
using PawsForApplause.Models;

namespace PawsForApplause.Controllers
{
    [Authorize]
    public class ShowsController : Controller
    {
        private readonly PawsForApplauseContext _context;

        public ShowsController(PawsForApplauseContext context)
        {
            _context = context;
        }

        // GET: Shows
        public async Task<IActionResult> Index()
        {
            var pawsForApplauseContext = _context.Show.Include(s => s.Category).Include(s => s.User).Include(s => s.Venue);
            return View(await pawsForApplauseContext.ToListAsync());
        }

        // GET: Shows/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var show = await _context.Show
                .Include(s => s.Category)
                .Include(s => s.User)
                .Include(s => s.Venue)
                .FirstOrDefaultAsync(m => m.ShowId == id);
            if (show == null)
            {
                return NotFound();
            }

            return View(show);
        }

        // GET: Shows/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Category, "CategoryId", "CategoryName");
            ViewData["UserId"] = new SelectList(_context.Set<User>(), "Id", "FullName");
            ViewData["VenueId"] = new SelectList(_context.Set<Venue>(), "VenueId", "FullAddress");
            

            return View();
        }

        // POST: Shows/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ShowId,Name,Description,Date,Location,Created,Filename,CategoryId,UserId,VenueId,FormFile")] Show show)
        {
            if (ModelState.IsValid)
            {
                //1) Save the file (optional)
                if (show.FormFile != null)
                {
                    //Create a unique filename using GUID
                    string fileName = Path.GetFileNameWithoutExtension(show.FormFile.FileName)+"_"+Guid.NewGuid().ToString()+Path.GetExtension(show.FormFile.FileName);

                    //Initialize the filename in photo record
                    show.Filename = fileName;

                    //Get the file path to save the file. Use Path.Combine to ensure the correct path format
                    string savefilePath = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot","photos", fileName);
                    
                    //Save file
                    using (FileStream fileStream = new FileStream(savefilePath, FileMode.Create))
                    {
                        await show.FormFile.CopyToAsync(fileStream);
                    }
                    
                }

                //set the Created date to the current date/time
                show.Created = DateTime.Now;
                show.LastModified = show.Created;


                _context.Add(show);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Category, "CategoryId", "CategoryName");
            ViewData["UserId"] = new SelectList(_context.Set<User>(), "Id", "FullName", show.UserId);
            ViewData["VenueId"] = new SelectList(_context.Set<Venue>(), "VenueId", "FullAddress", show.VenueId);
            return View(show);
        }

        // GET: Shows/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var show = await _context.Show.FindAsync(id);
            if (show == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Category, "CategoryId", "CategoryName");
            ViewData["UserId"] = new SelectList(_context.Set<User>(), "Id", "FullName", show.UserId);
            ViewData["VenueId"] = new SelectList(_context.Set<Venue>(), "VenueId", "FullAddress", show.VenueId);
            

            return View(show);
        }

        // POST: Shows/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ShowId,Name,Description,Date,Location,Created,Filename,CategoryId,UserId,VenueId,FormFile")] Show show)
        {
            if (id != show.ShowId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                //1) Save the file (optional)
                if (show.FormFile != null)
                {
                    //Create a unique filename using GUID
                    string fileName = Path.GetFileNameWithoutExtension(show.FormFile.FileName) + "_" + Guid.NewGuid().ToString() + Path.GetExtension(show.FormFile.FileName);

                    //Initialize the filename in photo record
                    show.Filename = fileName;

                    //Get the file path to save the file. Use Path.Combine to ensure the correct path format
                    string savefilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "photos", fileName);

                    //Save file
                    using (FileStream fileStream = new FileStream(savefilePath, FileMode.Create))
                    {
                        await show.FormFile.CopyToAsync(fileStream);
                    }

                    //delete the old file
                    var oldShow = await _context.Show.AsNoTracking().FirstOrDefaultAsync(p => p.ShowId == id);
                    if (oldShow != null && !string.IsNullOrEmpty(oldShow.Filename))
                    {
                        string oldFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "photos", oldShow.Filename);
                        if (System.IO.File.Exists(oldFilePath))
                        {
                            System.IO.File.Delete(oldFilePath);
                        }
                    }

                }

                //Keep the original Created date
                var existingShow = await _context.Show.AsNoTracking().FirstOrDefaultAsync(s => s.ShowId == id);
                show.Created = existingShow.Created;

                show.LastModified = DateTime.Now;

                try
                {
                    _context.Update(show);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShowExists(show.ShowId))
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
            ViewData["CategoryId"] = new SelectList(_context.Category, "CategoryId", "CategoryName");
            ViewData["UserId"] = new SelectList(_context.Set<User>(), "Id", "FullName", show.UserId);
            ViewData["VenueId"] = new SelectList(_context.Set<Venue>(), "VenueId", "FullAddress", show.VenueId);
            return View(show);
        }

        // GET: Shows/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var show = await _context.Show
                .Include(s => s.User)
                .Include(s => s.Venue)
                .FirstOrDefaultAsync(m => m.ShowId == id);
            if (show == null)
            {
                return NotFound();
            }

            return View(show);
        }

        // POST: Shows/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var show = await _context.Show.FindAsync(id);
            if (show != null)
            {
                if (!string.IsNullOrEmpty(show.Filename))
                {
                    string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "photos", show.Filename);
                    if (System.IO.File.Exists(filePath))
                    {
                        System.IO.File.Delete(filePath);
                    }
                }

                _context.Show.Remove(show);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShowExists(int id)
        {
            return _context.Show.Any(e => e.ShowId == id);
        }
    }
}
