using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PMIS2.DTO;
using PMISBussinessLayer.Data;
using PMISBussinessLayer.Entities;
using PMISBussinessLayer.Repositories;

namespace PMIS2.Controllers
{
    [Authorize]
    public class ProjectPhasesController : Controller
    {
      
        
        private readonly ApplicationDbContext _context;
        private readonly IProjectPhaseRepository projectPhaseRepository;
        private readonly IPhaseRepository phaseRepository;
        private readonly IProjectRepository projectRepository;

        public ProjectPhasesController(ApplicationDbContext context, IProjectPhaseRepository projectPhaseRepository, IPhaseRepository phaseRepository, IProjectRepository projectRepository)
        {
            _context = context;
            this.projectPhaseRepository = projectPhaseRepository;
            this.phaseRepository = phaseRepository;
            this.projectRepository = projectRepository;
        }

        // GET: ProjectPhases
        public IActionResult Index()
        {
            var applicationDbContext = _context.ProjectPhases.Include(p => p.Phase).Include(p => p.Project);
            return View(projectPhaseRepository.GetAllProjectPhase());
        }

        // GET: ProjectPhases/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectPhase = await _context.ProjectPhases
                .Include(p => p.Phase)
                .Include(p => p.Project)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (projectPhase == null)
            {
                return NotFound();
            }

            return View(projectPhase);
        }

        // GET: ProjectPhases/Create
        public IActionResult Create(int id)
        {
            var ph = phaseRepository.GetAllPhase();
            ViewBag.phasess = ph;
            var proj = _context.Projects.SingleOrDefault(i => i.Id == id);
            //var project = projectRepository.GetProject(id);
            ViewBag.project = proj;


            return View();
        }

        // POST: ProjectPhases/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(InsertProjectPhaseDTO insertProjectPhaseDTO)
        {
            if (ModelState.IsValid)
            {
                var projectPhase = new ProjectPhase()
                {
                    ProjectId = insertProjectPhaseDTO.ProjectId,
                    PhaseId=insertProjectPhaseDTO.PhaseId,
                    StartDate=insertProjectPhaseDTO.StartDate,
                    EndDate=insertProjectPhaseDTO.EndDate,

                };
                projectPhaseRepository.InsertProjectPhase(projectPhase);
                return RedirectToAction(nameof(Index));
            }
           
            return View(insertProjectPhaseDTO);
        }

        // GET: ProjectPhases/Edit/5
        public IActionResult Edit(int id)
        {


            var pph = _context.ProjectPhases.Include(q => q.Project).Include(v => v.Phase).SingleOrDefault(x=>x.Id==id);

            //var pph = projectPhaseRepository.GetProjectPhase(id);

            ViewBag.ProjectPhase = pph;
            if (pph == null)
            {
                return NotFound();
            }
           
            return View();
        }

        // POST: ProjectPhases/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(UpdateProjectPhases ProjectPhasesDTO)
        {
           

            if (ModelState.IsValid)
            {
                try
                {
                    var projectPhase = new ProjectPhase()
                    {
                        ProjectId = ProjectPhasesDTO.ProjectId,
                        PhaseId = ProjectPhasesDTO.PhaseId,
                        StartDate = ProjectPhasesDTO.StartDate,
                        EndDate = ProjectPhasesDTO.EndDate,
                        Id= ProjectPhasesDTO.ProjectPhaseId,

                    };
                    projectPhaseRepository.UpdateProjectPhase(projectPhase);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectPhaseExists(ProjectPhasesDTO.ProjectPhaseId))
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
           
            return View(ProjectPhasesDTO);
        }

        // GET: ProjectPhases/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectPhase = await _context.ProjectPhases
                .Include(p => p.Phase)
                .Include(p => p.Project)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (projectPhase == null)
            {
                return NotFound();
            }

            return View(projectPhase);
        }

        // POST: ProjectPhases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var projectPhase = await _context.ProjectPhases.FindAsync(id);
            _context.ProjectPhases.Remove(projectPhase);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjectPhaseExists(int id)
        {
            return _context.ProjectPhases.Any(e => e.Id == id);
        }
    }
}
