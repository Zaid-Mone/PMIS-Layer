using PMISBussinessLayer.Data;
using PMISBussinessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PMISBussinessLayer.Repositories
{
    public class PhaseRepository : IPhaseRepository
    {
        private readonly ApplicationDbContext context;
        public PhaseRepository(ApplicationDbContext context)
        {
            this.context = context;

        }
        public void DeletePhase(Phase phase)
        {
            context.Phases.Remove(phase);
            context.SaveChanges();

        }

        public List<Phase> GetAllPhase()
        {
          return  context.Phases.ToList();
        }

        public Phase GetPhase(int phaseid)
        {
            return context.Phases.SingleOrDefault(x=>x.Id== phaseid);
        }

        public void InsertPhase(Phase phase)
        {
            context.Phases.Add(phase);
            context.SaveChanges();

        }

        public void UpdatePhase(Phase phase)
        {
            context.Phases.Update(phase);
            context.SaveChanges();
        }
    }
}
