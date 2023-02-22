using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PMIS2.DTO;
using PMISBussinessLayer.Data;
using PMISBussinessLayer.Entities;
using PMISBussinessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PMIS2.Controllers
{
    public class DeliverableController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IDeliverableRepository deliverableRepository;
        private readonly IProjectPhaseRepository projectPhaseRepository;
        private readonly IProjectRepository projectRepository;

        public DeliverableController(ApplicationDbContext context, IDeliverableRepository deliverableRepository,
            IProjectPhaseRepository projectPhaseRepository, IProjectRepository projectRepository)
        {
            _context = context;
            this.deliverableRepository = deliverableRepository;
            this.projectPhaseRepository = projectPhaseRepository;
            this.projectRepository = projectRepository;
        }

        // GET: Deliverable
        public IActionResult Index()
        {

            return View(deliverableRepository.GetAllDeliverable());
        }

        // GET: Deliverable/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deliverable = await _context.Deliverables
                .Include(d => d.ProjectPhase)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (deliverable == null)
            {
                return NotFound();
            }

            return View(deliverable);
        }

        // GET: Deliverable/Create
        public IActionResult Create(int id)
        {
            var p = projectRepository.GetAllProject();
            ViewBag.project = p;
            // all projectstatus

            var ph = projectPhaseRepository.GetProjectPhase(id);
            ViewBag.ProjectPhase = ph;
            // all phases


            return View();
        }

        // POST: Deliverable/Create
        // To protect from overposting attacks, 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(InsertDeliverableDTO insertDeliverableDTO)
        {
            if (ModelState.IsValid)
            {
                var deliverable = new Deliverable()
                {
                    Description = insertDeliverableDTO.Description,
                    ProjectPhaseId = insertDeliverableDTO.ProjectPhaseId,
                    StartDate = insertDeliverableDTO.StartDate,
                    EndDate = insertDeliverableDTO.EndDate,

                };
                deliverableRepository.InsertDeliverable(deliverable);

                return RedirectToAction(nameof(Index));
            }

            return View(insertDeliverableDTO);
        }

        // GET: Deliverable/Edit/5
        public IActionResult Edit(int id)
        {
            var deliverable = deliverableRepository.GetDeliverable(id);
            ViewBag.Deliverable = deliverable;
            var ph = projectPhaseRepository.GetProjectPhase(deliverable.ProjectPhaseId);
            ViewBag.ProjectPhase = ph;

            if (deliverable == null)
            {
                return NotFound();
            }

            return View(deliverable);
        }

        // POST: Deliverable/Edit/5
        // To protect from overposting attacks,
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Deliverable deliverable)
        {


            if (ModelState.IsValid)
            {
                try
                {
                    deliverableRepository.UpdateDeliverable(deliverable);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DeliverableExists(deliverable.Id))
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

            return View(deliverable);
        }

        // GET: Deliverable/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deliverable = await _context.Deliverables
                .Include(d => d.ProjectPhase)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (deliverable == null)
            {
                return NotFound();
            }

            return View(deliverable);
        }

        // POST: Deliverable/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var deliverable = await _context.Deliverables.FindAsync(id);
            _context.Deliverables.Remove(deliverable);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DeliverableExists(int id)
        {
            return _context.Deliverables.Any(e => e.Id == id);
        }
    }
   

}
