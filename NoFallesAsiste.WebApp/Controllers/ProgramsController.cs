using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NoFallesAsiste.WebApp.Contracts;
using NoFallesAsiste.WebApp.Data;
using NoFallesAsiste.WebApp.Models;

namespace NoFallesAsiste.WebAppApp.Controllers
{
    public class ProgramssController : Controller
    {
        private readonly IProgramsRepository _context;

        public ProgramssController(IProgramsRepository context)
        {
            _context = context;
        }

        // GET: Programss
        public IActionResult Index()
        {
            var programs = _context.GetAll();
            return View(programs);
        }

        // GET: Programss/Details/5
        public IActionResult Details(int id)
        {
            var programs = _context.GetPrograms(id);
            if (programs == null)
            {
                return NotFound();
            }

            return View(programs);
        }

        // GET: Programss/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Create([Bind("ProgramsId,Name,Description,Version,TypeProgramId")] Programs Programs)
        {
            if (ModelState.IsValid)
            {
                _context.CreatePrograms(Programs);
                return RedirectToAction(nameof(Index));
            }
            return View(Programs);
        }

        // GET: Programss/Edit/5
        public IActionResult Edit(int id)
        {
            var Programs = _context.GetPrograms(id);
            if (Programs == null)
            {
                return NotFound();
            }
            return View(Programs);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("ProgramsId,Name,Description,Version,TypeProgramId")] Programs programs)
        {
            if (id != programs.ProgramsId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.EditPrograms(programs);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.ProgramsExists(id))
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
            return View(programs);
        }

        // GET: Programss/Delete/5
        public IActionResult Delete(int id)
        {
            var programs = _context.GetPrograms(id);
            if (programs == null)
            {
                return NotFound();
            }

            return View(programs);
        }

        // POST: Programss/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _context.DeletePrograms(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
