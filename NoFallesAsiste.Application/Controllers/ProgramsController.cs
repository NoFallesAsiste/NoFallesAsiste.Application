using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NoFallesAsiste.Application.Contracts;
using NoFallesAsiste.Application.Data;
using NoFallesAsiste.Application.Models;

namespace NoFallesAsiste.Application.Controllers
{
    public class ProgramsController : Controller
    {
        private readonly IProgramsRepository _context;

        public ProgramsController(IProgramsRepository context)
        {
            _context = context;
        }

        // GET: programss
        public IActionResult Index()
        {
            var programs = _context.GetAll();
            return View(programs);
        }

        // GET: programss/Details/5
        public IActionResult Details(int id)
        {
            var programs = _context.GetPrograms(id);
            if (programs == null)
            {
                return NotFound();
            }

            return View(programs);
        }

        // GET: programss/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,Description,Version,TypeProgramId")] Programs programs)
        {
            if (ModelState.IsValid)
            {
                _context.CreatePrograms(programs);
                return RedirectToAction(nameof(Index));
            }
            return View(programs);
        }

        // GET: programss/Edit/5
        public IActionResult Edit(int id)
        {
            var programs = _context.GetPrograms(id);
            if (programs == null)
            {
                return NotFound();
            }
            return View(programs);
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

        // GET: programss/Delete/5
        public IActionResult Delete(int id)
        {
            var programs = _context.GetPrograms(id);
            if (programs == null)
            {
                return NotFound();
            }

            return View(programs);
        }

        // POST: programss/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _context.DeletePrograms(id);

            return RedirectToAction(nameof(Index));
        }
    }
}