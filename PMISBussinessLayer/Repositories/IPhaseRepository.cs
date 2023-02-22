using PMISBussinessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PMISBussinessLayer.Repositories
{
   public interface IPhaseRepository
    {
        public List<Phase> GetAllPhase();
        public void InsertPhase(Phase phase);
        public void UpdatePhase(Phase phase);
        public void DeletePhase(Phase phase);
        public Phase GetPhase(int phaseid);
    }
}
