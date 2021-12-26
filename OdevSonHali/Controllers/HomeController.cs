using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MovieWebApp_ASP.NET.Models;
using OdevSonHali.Data;
using OdevSonHali.Managers;
using OdevSonHali.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace OdevSonHali.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        
        public HomeController(ApplicationDbContext context)
        {
            //_logger = logger;
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            IndexManager Manager = new IndexManager();
            Manager.Story = _context.Story.OrderByDescending(x => x.ModifiedOn).ToList();
            Manager.Category = _context.Category.ToList();
            return View(Manager);
        }
        public async Task<IActionResult> Begen(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            
            var story1 = await _context.Story.FindAsync(id);
            story1.LikeCount++;
            _context.Update(story1);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Select(int? id)
        {
            Category cat = _context.Category.Find(id);
            List<Story> stry = _context.Story.Where(m => m.CategoryId == id).ToList();
            if (cat == null)
            {
                return RedirectToAction("Home", "Index");
            }
            IndexManager Manager = new IndexManager();
            Manager.Story = stry.ToList();
            Manager.Category = _context.Category.ToList();
            return View("Index", Manager);
        }
        public IActionResult SonCikanlar()
        {
            IndexManager Manager = new IndexManager();
            Manager.Story = _context.Story.OrderByDescending(x => x.CreatedOn).ToList();
            Manager.Category = _context.Category.ToList();
            return View("Index", Manager);
        }
        public IActionResult EnBegenilenler()
        {
            IndexManager Manager = new IndexManager();
            Manager.Story = _context.Story.OrderByDescending(x => x.LikeCount).ToList();
            Manager.Category = _context.Category.ToList();
            return View("Index", Manager);
        }
        public IActionResult Privacy()
        {
            return View();
        }
        //[Authorize(Roles = "Admin")]
        public IActionResult Yonetim()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }



        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Set<Category>(), "Id", "Title");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CreatedOn,ModifiedOn,ModifiedUsername,Title,Text,IsDraft,LikeCount,CategoryId")] Story story)
        {
            if (ModelState.IsValid)
            {
                _context.Add(story);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Set<Category>(), "Id", "Title", story.CategoryId);
            return View(story);
        }
    }
}
