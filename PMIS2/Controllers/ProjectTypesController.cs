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
    public class ProjectTypesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IProjectTypeRepository ProjectTypeRepository;

        public ProjectTypesController(ApplicationDbContext context , IProjectTypeRepository ProjectTypeRepository)
        {
            _context = context;
            this.ProjectTypeRepository = ProjectTypeRepository;
        }

        // GET: ProjectTypes
        public IActionResult Index()
        {
            return View(ProjectTypeRepository.GetAllProjectType());
        }

        // GET: ProjectTypes/Details/5
        public IActionResult Details(int id)
        {
            var projectType = ProjectTypeRepository.GetProjectType(id);

            
            if (projectType == null)
            {
                return NotFound();
            }

            return View(projectType);
        }

        // GET: ProjectTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProjectTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create( ProjectType projectType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(projectType);
                ProjectTypeRepository.InsertProjectType(projectType);
                return RedirectToAction(nameof(Index));
            }
            return View(projectType);
        }

        // GET: ProjectTypes/Edit/5
        public IActionResult Edit(int id)
        {
           

            var projectType = ProjectTypeRepository.GetProjectType(id);
            if (projectType == null)
            {
                return NotFound();
            }
            return View(projectType);
        }

        // POST: ProjectTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ProjectType projectType)
        {
          

            if (ModelState.IsValid)
            {
                try
                {

                    ProjectTypeRepository.UpdateProjectType(projectType);

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectTypeExists(projectType.Id))
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
            return View(projectType);
        }

        // GET: ProjectTypes/Delete/5
        public IActionResult Delete(int id)
        {
           

            var projectType = ProjectTypeRepository.GetProjectType(id);

            if (projectType == null)
            {
                return NotFound();
            }

            return View(projectType);
        }

        // POST: ProjectTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var projectType = ProjectTypeRepository.GetProjectType(id);

            return RedirectToAction(nameof(Index));
        }

        private bool ProjectTypeExists(int id)
        {
            return _context.ProjectTypes.Any(e => e.Id == id);
        }
    }
}
