using PMISBussinessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PMISBussinessLayer.Repositories
{
   public interface IProjectPhaseRepository
    {
        public List<ProjectPhase> GetAllProjectPhase();
        public void InsertProjectPhase(ProjectPhase projectphase);
        public void UpdateProjectPhase(ProjectPhase projectphase);
        public void DeleteProjectPhase(ProjectPhase projectphase);
        public ProjectPhase GetProjectPhase(int projectphaseid);
        public List<Project> getallprojectmangerProject(string projectmangerid);
    }
}
