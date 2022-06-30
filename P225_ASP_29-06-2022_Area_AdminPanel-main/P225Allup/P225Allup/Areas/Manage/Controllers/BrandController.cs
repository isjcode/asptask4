using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using P225Allup.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace P225Allup.Areas.Manage.Controllers
{
    [Area("manage")]
    public class BrandController : Controller
    {
        private readonly AppDbContext _context;

        public BrandController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Brands.ToListAsync());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateBrand(Studnet studnet)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Create");
            }

            return Content($"{studnet.Name} {studnet.SurName} {studnet.Email}");
        }
    }

    public class Studnet
    {
        [Required]
        [StringLength(5)]
        public string Name { get; set; }
        public string SurName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public int Age { get; set; }

    }
}
