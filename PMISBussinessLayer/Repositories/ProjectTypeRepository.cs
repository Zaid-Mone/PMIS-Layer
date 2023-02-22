using PMISBussinessLayer.Data;
using PMISBussinessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PMISBussinessLayer.Repositories
{
    public class ProjectTypeRepository : IProjectTypeRepository
    {
        private readonly ApplicationDbContext context;
        public ProjectTypeRepository(ApplicationDbContext context)
        {
            this.context = context;

        }
        public void DeleteProjectType(ProjectType projectType)
        {
            context.ProjectTypes.Remove(projectType);
            context.SaveChanges();
        }

        public List<ProjectType> GetAllProjectType()
        {
         return   context.ProjectTypes.ToList();
        }

        public ProjectType GetProjectType(int projectTypeid)
        {
          return  context.ProjectTypes.SingleOrDefault(x => x.Id == projectTypeid);
        }

        public void InsertProjectType(ProjectType projectType)
        {
            context.ProjectTypes.Add(projectType);
            context.SaveChanges();
        }

        public void UpdateProjectType(ProjectType projectType)
        {
            context.ProjectTypes.Update(projectType);
            context.SaveChanges();
        }
    }
}
