using PMISBussinessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PMISBussinessLayer.Repositories
{
  public  interface IProjectRepository
    {
        public List<Project> GetAllProject();
        public void InsertProject(Project project);
        public void UpdateProject(Project project);
        public void DeleteProject(Project project);
        public Project GetProject(int projectid);
        //public List<Project> getallprojectmangerproject(string projectmangerid);
    }
}
