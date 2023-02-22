using PMISBussinessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PMISBussinessLayer.Repositories
{
  public  interface IProjectStatusRepository
    {
        public List<ProjectStatus> GetAllProjectStatus();
        public void InsertProjectStatus(ProjectStatus projectStatus);
        public void UpdateProjectStatus(ProjectStatus projectStatus);
        public void DeleteProjectStatus(ProjectStatus projectStatus);
        public ProjectStatus GetProjectStatus(int projectStatusid);
    }
}
