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
    public class ProgramasController : Controller
    {
        private readonly IProgramaRepository _context;

        public ProgramasController(IProgramaRepository context)
        {
            _context = context;
        }

        // GET: Programas
        public IActionResult Index()
        {
            var programa = _context.GetAll();
            return View(programa);
        }

        // GET: Programas/Details/5
        public IActionResult Details(int id)
        {
            var programa = _context.GetPrograma(id);
            if (programa == null)
            {
                return NotFound();
            }

            return View(programa);
        }

        // GET: Programas/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,Description,Version,TypeProgramId")] Programa programa)
        {
            if (ModelState.IsValid)
            {
                _context.CreatePrograma(programa);
                return RedirectToAction(nameof(Index));
            }
            return View(programa);
        }

        // GET: Programas/Edit/5
        public IActionResult Edit(int id)
        {
            var programa = _context.GetPrograma(id);
            if (programa == null)
            {
                return NotFound();
            }
            return View(programa);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name,Description,Version,TypeProgramId")] Programa programa)
        {
            if (id != programa.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.EditPrograma(programa);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.ProgramaExists(id))
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
            return View(programa);
        }

        // GET: Programas/Delete/5
        public IActionResult Delete(int id)
        {
            var Programa = _context.GetPrograma(id);
            if (Programa== null)
            {
                return NotFound();
            }

            return View(Programa);
        }

        // POST: Programas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _context.DeletePrograma(id);

            return RedirectToAction(nameof(Index));
        }
    }
}