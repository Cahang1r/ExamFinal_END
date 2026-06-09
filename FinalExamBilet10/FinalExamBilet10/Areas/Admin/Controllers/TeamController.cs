using FinalExamBilet10.Data;
using FinalExamBilet10.Models;
using FinalExamBilet10.ViewModels.Team;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinalExamBilet10.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]
    public class TeamController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        public TeamController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }


        public async Task<IActionResult> Index()
        {
            var teams = await _context.Teams.ToListAsync();
            return View(teams);
        }

        [HttpGet]

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Create(TeamCreateVM model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            Team team = new()
            {
                Name = model.Name,
                Job = model.Job,
                Description = model.Description
            };

            if (model.Image != null)
            {
                var file = model.Image;
                var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                var path = Path.Combine(_env.WebRootPath, "assets/images", fileName);

                using FileStream stream = new(path, FileMode.Create);
                await file.CopyToAsync(stream);

                team.Image = fileName;
            }

            await _context.Teams.AddAsync(team);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]

        public async Task<IActionResult> Detail(int? id)
        {
            if (id is null) return BadRequest();
            var team = await _context.Teams.FindAsync(id.Value);
            if (team is null) return NotFound();

            return View(team);
        }

        [HttpPost]

        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null) return BadRequest();
            var team = await _context.Teams.FindAsync(id.Value);
            if (team is null) return NotFound();

            var oldpath = Path.Combine(_env.WebRootPath, "assets/images", team.Image);
            if (System.IO.File.Exists(oldpath))
            {
                System.IO.File.Delete(oldpath);
            }

            _context.Teams.Remove(team);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> Update(int? id)
        {
            if (id is null) return BadRequest();
            var team = await _context.Teams.FindAsync(id.Value);
            if (team is null) return NotFound();

            return View(new TeamUpdateVM
            {
                Image =team.Image,
                Name=team.Name,
                Job =team.Job,
                Description =team.Description
            });

        }

        [HttpPost]

        public async Task<IActionResult> Update(int? id,TeamUpdateVM model)
        {
            if (!ModelState.IsValid) return View(model);
            if (id is null) return BadRequest();
            var team = await _context.Teams.FindAsync(id.Value);
            if (team is null) return NotFound();

          

            if (model.NewImage != null)
            {
                var oldpath = Path.Combine(_env.WebRootPath, "assets/images", team.Image);
                if (System.IO.File.Exists(oldpath))
                {
                    System.IO.File.Delete(oldpath);
                } 


                var file = model.NewImage;
                var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                var path = Path.Combine(_env.WebRootPath, "assets/images", fileName);

                using FileStream stream = new(path, FileMode.Create);
                await file.CopyToAsync(stream);

                team.Image = fileName;
            }

            team.Description = model.Description;
            team.Name = model.Name;
            team.Job = model.Job;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
