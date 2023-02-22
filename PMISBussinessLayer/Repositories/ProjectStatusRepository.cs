using PMISBussinessLayer.Data;
using PMISBussinessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PMISBussinessLayer.Repositories
{
    public class ProjectStatusRepository : IProjectStatusRepository
    {
        private readonly ApplicationDbContext context;
        public ProjectStatusRepository(ApplicationDbContext context)
        {
            this.context = context;

        }
        public void DeleteProjectStatus(ProjectStatus projectStatus)
        {
            context.ProjectStatuses.Remove(projectStatus);
            context.SaveChanges();

        }

        public List<ProjectStatus> GetAllProjectStatus()
        {
          return  context.ProjectStatuses.ToList();
        }

        public ProjectStatus GetProjectStatus(int projectStatusid)
        {
            return context.ProjectStatuses.SingleOrDefault(x => x.Id == projectStatusid);
        }

        public void InsertProjectStatus(ProjectStatus projectStatus)
        {
            context.ProjectStatuses.Add(projectStatus);
            context.SaveChanges();
        }

        public void UpdateProjectStatus(ProjectStatus projectStatus)
        {
            context.ProjectStatuses.Update(projectStatus);
            context.SaveChanges();
        }
    }
}
