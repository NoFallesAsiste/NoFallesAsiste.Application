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
    public class FichasController : Controller
    {
        private readonly IFichaRepository _context;

        public FichasController(IFichaRepository context)
        {
            _context = context;
        }

        // GET: Fichas
        public IActionResult Index()
        {
            var ficha = _context.GetAll();
            return View(ficha);
        }

        // GET: Fichas/Details/5
        public IActionResult Details(int id)
        {
            var ficha = _context.GetFicha(id);
            if (ficha == null)
            {
                return NotFound();
            }

            return View(ficha);
        }

        // GET: Fichas/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,StartTraining,EndTraining,StartPractice,HoraryId,ProgramId")] Ficha ficha)
        {
            if (ModelState.IsValid)
            {
                _context.CreateFicha(ficha);
                return RedirectToAction(nameof(Index));
            }
            return View(ficha);
        }

        // GET: Fichas/Edit/5
        public IActionResult Edit(int id)
        {
            var ficha = _context.GetFicha(id);
            if (ficha == null)
            {
                return NotFound();
            }
            return View(ficha);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,StartTraining,EndTraining,StartPractice,HoraryId,ProgramId")] Ficha ficha)
        {
            if (id != ficha.FichaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.EditFicha(ficha);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.FichaExists(id))
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
            return View(ficha);
        }

        // GET: Fichas/Delete/5
        public IActionResult Delete(int id)
        {
            var ficha = _context.GetFicha(id);
            if (ficha == null)
            {
                return NotFound();
            }

            return View(ficha);
        }

        // POST: Fichas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _context.DeleteFicha(id);

            return RedirectToAction(nameof(Index));
        }
    }
}