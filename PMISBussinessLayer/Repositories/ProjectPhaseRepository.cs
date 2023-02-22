using Microsoft.EntityFrameworkCore;
using PMISBussinessLayer.Data;
using PMISBussinessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PMISBussinessLayer.Repositories
{
    public class ProjectPhaseRepository : IProjectPhaseRepository
    {
        private readonly ApplicationDbContext context;

        public ProjectPhaseRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public void DeleteProjectPhase(ProjectPhase projectphase)
        {
            context.ProjectPhases.Remove(projectphase);
            context.SaveChanges();
        }

        public List<Project> getallprojectmangerProject(string projectmangerid)
        {
            return context.Projects.Where(x => x.ProjectMangerId == projectmangerid).ToList();
        }
       

        public List<ProjectPhase> GetAllProjectPhase()
        {
            
            return context.ProjectPhases.Include(q => q.Project).Include(v => v.Phase).ToList();
        }

        public ProjectPhase GetProjectPhase(int projectphaseid)
        {
            return context.ProjectPhases.SingleOrDefault(q => q.Id == projectphaseid);
        }

        public void InsertProjectPhase(ProjectPhase projectphase)
        {
            context.ProjectPhases.Add(projectphase);
            context.SaveChanges();
        }

        public void UpdateProjectPhase(ProjectPhase projectphase)
        {
            context.ProjectPhases.Update(projectphase);
            context.SaveChanges();
        }
    }
}
