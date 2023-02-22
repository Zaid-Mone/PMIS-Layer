using PMISBussinessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PMISBussinessLayer.Repositories
{
    public interface IProjectTypeRepository
    {
        public List<ProjectType> GetAllProjectType();
        public void InsertProjectType(ProjectType projectType);
        public void UpdateProjectType(ProjectType projectType);
        public void DeleteProjectType(ProjectType projectType);
        public ProjectType GetProjectType(int projectTypeid);
    }   
}
