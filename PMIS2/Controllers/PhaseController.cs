using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PMISBussinessLayer.Data;
using PMISBussinessLayer.Entities;
using PMISBussinessLayer.Repositories;

namespace PMIS2.Controllers
{
    [Authorize]
    public class PhaseController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IPhaseRepository phaseRepository;
        public PhaseController(ApplicationDbContext context, IPhaseRepository phaseRepository)
        {
            _context = context;
            this.phaseRepository = phaseRepository;
        }

        // GET: Phase
        public IActionResult Index()
        {
            return View(phaseRepository.GetAllPhase());
        }

        // GET: Phase/Details/5
        public IActionResult Details(int id)
        {
            var Phase = phaseRepository.GetPhase(id);
           
            if (Phase == null)
            {
                return NotFound();
            }

            return View(Phase);
        }

        // GET: Phase/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Phase/Create
        // To protect from overposting attacks
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create( Phase phase)
        {
            if (ModelState.IsValid)
            {
                _context.Add(phase);
                phaseRepository.InsertPhase(phase);
                return RedirectToAction(nameof(Index));
            }
            return View(phase);
        }

        // GET: Phase/Edit/5
        public IActionResult Edit(int id)
        {
            var phase = phaseRepository.GetPhase(id);
          
            if (phase == null)
            {
                return NotFound();
            }
            return View(phase);
        }

        // POST: Phase/Edit/5
        // To protect from overposting attacks
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Phase phase)
        {
          
            if (ModelState.IsValid)
            {
                try
                {
                    phaseRepository.UpdatePhase(phase);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhaseExists(phase.Id))
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
            return View(phase);
        }

        // GET: Phase/Delete/5
        public IActionResult Delete(int id)
        {
            var phase = phaseRepository.GetPhase(id);
          
            if (phase == null)
            {
                return NotFound();
            }

            return View(phase);
        }

        // POST: Phase/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var phase = phaseRepository.GetPhase(id);

            phaseRepository.DeletePhase(phase);
            return RedirectToAction(nameof(Index));
        }

        private bool PhaseExists(int id)
        {
            return _context.Phases.Any(e => e.Id == id);
        }
    }
}
