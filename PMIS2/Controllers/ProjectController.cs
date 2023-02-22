using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
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
    public class ProjectController : Controller
    {
        private readonly ApplicationDbContext _context;
        
        private readonly IProjectRepository projectRepository;
        private readonly IProjectTypeRepository projectTypeRepository;
        private readonly IProjectStatusRepository ProjectStatusRepository;
        private readonly IClientRepository ClientRepository;
        private readonly IPhaseRepository PhaseRepository;




        public ProjectController(ApplicationDbContext context, IProjectRepository projectRepository, 
            IProjectTypeRepository projectTypeRepository, IProjectStatusRepository ProjectStatusRepository,
            IClientRepository ClientRepository, IPhaseRepository PhaseRepository)
        {
            _context = context;
            this.projectRepository = projectRepository;
            this.projectTypeRepository = projectTypeRepository;
            this.ProjectStatusRepository = ProjectStatusRepository;
            this.ClientRepository = ClientRepository;
            this.PhaseRepository = PhaseRepository;
        }

        // GET: Project
        public IActionResult Index()
        {

            return View(projectRepository.GetAllProject());
        }

        // GET: Project/Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Projects
                .Include(p => p.ProjectManger)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        // GET: Project/Create
        public IActionResult Create()
        {
            // all projectType
           
                var pType= projectTypeRepository.GetAllProjectType();
            ViewBag.projectType = pType;
            // all projectstatus
           
                var pStatus= ProjectStatusRepository.GetAllProjectStatus();
            ViewBag.ProjectStatus = pStatus;
            // all phases
            var phase = PhaseRepository.GetAllPhase();
            ViewBag.Phase = phase;
            // all clients
            var client = ClientRepository.GetAllClients();
            ViewBag.Client = client;

            ViewData["ProjectStatusId"] = new SelectList(pStatus, "Id", "Status");
            ViewData["ProjectTypeId"] = new SelectList(pType, "Id", "Type");
            ViewData["ClientId"] = new SelectList(client, "Id", "Name");


            return View();
        }

        // POST: Project/Create
        // To protect from overposting attacks,
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(InsertProjectDTO insertProjectDTO)
        {
            var usr = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (ModelState.IsValid)
            {
                var project = new Project()
                {
                    EndDate = insertProjectDTO.EndDate,
                    StartDate=insertProjectDTO.StartDate,
                    ProjectStatusId = insertProjectDTO.ProjectStatusId,
                    ProjectTypeId = insertProjectDTO.ProjectTypeId,
                    ProjectName = insertProjectDTO.ProjectName,
                    ContractAmount = insertProjectDTO.ContractAmount,
                    ContractFileName = insertProjectDTO.ContractFile.FileName,
                    ContractFileType = insertProjectDTO.ContractFile.ContentType,
                    ClientId=insertProjectDTO.ClientId,
                    ProjectMangerId = usr,
                };
                Stream st = insertProjectDTO.ContractFile.OpenReadStream();
                using (BinaryReader bt = new BinaryReader(st))
                {
                    var byteFile = bt.ReadBytes((int)st.Length);
                    project.ContractFile = byteFile;
                    projectRepository.InsertProject(project);

                }
                return RedirectToAction(nameof(Index));
            }
            return View(insertProjectDTO);
        }

        // GET: Project/Edit
        public IActionResult Edit(int id)
        {

            var pType = projectTypeRepository.GetAllProjectType();
            ViewBag.projectType = pType;
            // all projectstatus

            var pStatus = ProjectStatusRepository.GetAllProjectStatus();
            ViewBag.ProjectStatus = pStatus;
            // all clients
            var client = ClientRepository.GetAllClients();
            ViewBag.Client = client;

            var project = projectRepository.GetProject(id);
            ViewBag.project = project;
            if (project == null)
            {
                return NotFound();
            }
            ViewData["ProjectStatusId"] = new SelectList(pStatus, "Id", "Status",project.ProjectStatusId);
            ViewData["ProjectTypeId"] = new SelectList(pType, "Id", "Type",project.ProjectTypeId);
            ViewData["ClientId"] = new SelectList(client, "Id", "Name",project.ClientId);
            return View();
        }

        // POST: Project/Edit
        // To protect from overposting attacks,
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  IActionResult Edit( UpdateProjectDTO projectDTO)
        {
        

            if (ModelState.IsValid)
            {
                try
                {
                    var usr = User.FindFirstValue(ClaimTypes.NameIdentifier);

                    if (projectDTO.ContractFile == null)
                    {
                        var obj = projectRepository.GetProject(projectDTO.ProjectId);
                        obj.ProjectName = projectDTO.ProjectName;
                        obj.ContractAmount = projectDTO.ContractAmount;
                        obj.StartDate = projectDTO.StartDate;
                        obj.EndDate = projectDTO.EndDate;
                        obj.ProjectStatusId = projectDTO.ProjectStatusId;
                        obj.ProjectTypeId = projectDTO.ProjectTypeId;
                        obj.ProjectMangerId = usr;
                        obj.ClientId = projectDTO.ClientId;
                        projectRepository.UpdateProject(obj);
                        return RedirectToAction("Index");
                    }
                else
                    {
                        var obj = projectRepository.GetProject(projectDTO.ProjectId);
                        obj.ProjectName = projectDTO.ProjectName;
                        obj.ContractAmount = projectDTO.ContractAmount;
                        obj.StartDate = projectDTO.StartDate;
                        obj.EndDate = projectDTO.EndDate;
                        obj.ProjectStatusId = projectDTO.ProjectStatusId;
                        obj.ProjectTypeId = projectDTO.ProjectTypeId;
                        obj.ClientId = projectDTO.ClientId;
                        obj.ProjectMangerId = usr;
                        obj.ContractFileType = projectDTO.ContractFile.ContentType;
                        obj.ContractFileName = projectDTO.ContractFile.FileName;
                        Stream st = projectDTO.ContractFile.OpenReadStream();
                        using (BinaryReader bt = new BinaryReader(st))
                        {
                            var byteFile = bt.ReadBytes((int)st.Length);
                            obj.ContractFile = byteFile;
                            projectRepository.UpdateProject(obj);

                        }
                        return RedirectToAction("Index");
                    }
                   
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectExists(projectDTO.ProjectId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }


            }
            return View(projectDTO);
        }

        // GET: Project/Delete
        public IActionResult Delete(int id)
        {
            var project = projectRepository.GetProject(id);


            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        // POST: Project/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var project = projectRepository.GetProject(id);

            projectRepository.DeleteProject(project);
            return RedirectToAction(nameof(Index));
        }

        private bool ProjectExists(int id)
        {
            return _context.Projects.Any(e => e.Id == id);
        }






        public FileStreamResult ViewContract(int id) // to open connection with browser
        {
            var file =  projectRepository.GetProject(id);
            Stream stream = new MemoryStream(file.ContractFile); // array of bytes 
            return new FileStreamResult(stream, file.ContractFileType);
        }
    }
}
