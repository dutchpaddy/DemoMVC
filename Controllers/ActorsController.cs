using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DemoMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoMVC.Controllers
{
    public class ActorsController : Controller
    {
        private ActorDbContext _context;

        public ActorsController( ActorDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View( _context.Actors.ToList());
        }
        
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
            public IActionResult Create( Actors actors )
        {
            if (ModelState.IsValid)
            {
                _context.Add(actors);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View( actors );
                
        }
        public IActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Delete(Actors actors)
        {
            if (ModelState.IsValid)
            {
                _context.Remove(actors);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(actors);

        }

    }
}
