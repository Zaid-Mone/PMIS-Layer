using Microsoft.EntityFrameworkCore;
using PMISBussinessLayer.Data;
using PMISBussinessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PMISBussinessLayer.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly ApplicationDbContext context;
        public ProjectRepository(ApplicationDbContext context)
        {
            this.context = context;

        }
        public void DeleteProject(Project project )
        {
            context.Projects.Remove(project);
            context.SaveChanges();
        }

        public List<Project> GetAllProject()
        {
            return context.Projects
                .Include(r=>r.ProjectType)
                .Include(b=>b.ProjectStatus)
                .Include(r=>r.Client)
                .ToList();
        }

        //public List<Project> getallprojectmangerproject(string projectmangerid)
        //{
        //    return context.Where(x => x.ProjectMangerId == projectmangerid).ToList();
        //}

        public Project GetProject(int projectid)
        {
            return context.Projects
                 .Include(r => r.ProjectType)
                .Include(b => b.ProjectStatus)
                .Include(r => r.Client)
                .SingleOrDefault(x => x.Id == projectid);
        }

        public void InsertProject(Project project)
        {

            context.Projects.Add(project);
            context.SaveChanges();
        }

        public void UpdateProject(Project project)
        {

            context.Projects.Update(project);
            context.SaveChanges();
        }
    }
}
