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
{[Authorize]
    public class ProjectStatusController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IProjectStatusRepository ProjectStatusRepository;
        public ProjectStatusController(ApplicationDbContext context, IProjectStatusRepository ProjectStatusRepository)
        {
            _context = context;
            this.ProjectStatusRepository = ProjectStatusRepository;
        }

        // GET: ProjectStatus
        public IActionResult Index()
        {
            return View(ProjectStatusRepository.GetAllProjectStatus());
        }

        // GET: ProjectStatus/Details
        public IActionResult Details(int id)
        {
            var projectStatus = ProjectStatusRepository.GetProjectStatus(id);

            if (projectStatus == null)
            {
                return NotFound();
            }

            return View(projectStatus);
        }

        // GET: ProjectStatus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProjectStatus/Create
        // To protect from overposting attacks
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create( ProjectStatus projectStatus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(projectStatus);
                ProjectStatusRepository.InsertProjectStatus(projectStatus);
                return RedirectToAction(nameof(Index));
            }
            return View(projectStatus);
        }

        // GET: ProjectStatus/Edit
        public IActionResult Edit(int id)
        {
           

            var projectStatus = ProjectStatusRepository.GetProjectStatus(id);
            if (projectStatus == null)
            {
                return NotFound();
            }
            return View(projectStatus);
        }

        // POST: ProjectStatus/Edit
        // To protect from overposting attacks
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit( ProjectStatus projectStatus)
        {
          

            if (ModelState.IsValid)
            {
                try
                {
                   
                    ProjectStatusRepository.UpdateProjectStatus(projectStatus);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectStatusExists(projectStatus.Id))
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
            return View(projectStatus);
        }

        // GET: ProjectStatus/Delete
        public IActionResult Delete(int id)
        {

            var projectStatus = ProjectStatusRepository.GetProjectStatus(id);
            if (projectStatus == null)
            {
                return NotFound();
            }

            return View(projectStatus);
        }

        // POST: ProjectStatus/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var projectStatus = ProjectStatusRepository.GetProjectStatus(id);
          
            return RedirectToAction(nameof(Index));
        }

        private bool ProjectStatusExists(int id)
        {
            return _context.ProjectStatuses.Any(e => e.Id == id);
        }
    }
}
