using Microsoft.EntityFrameworkCore;
using PMISBussinessLayer.Data;
using PMISBussinessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PMISBussinessLayer.Repositories
{
    public class DeliverableRepository : IDeliverableRepository
    {
        private readonly ApplicationDbContext context;
        public DeliverableRepository(ApplicationDbContext context)
        {
            this.context = context;

        }
        public void DeleteDeliverable(Deliverable deliverable)
        {
            context.Deliverables.Remove(deliverable);
            context.SaveChanges();
        }

        public List<Deliverable> GetAllDeliverable()
        {
            return context.Deliverables.Include(q => q.ProjectPhase).Include(v => v.ProjectPhase.Project).ToList();
        }

        public Deliverable GetDeliverable(int deliverableid)
        {
            return context.Deliverables.SingleOrDefault(x => x.Id == deliverableid);
        }

        public void InsertDeliverable(Deliverable deliverable)
        {

            context.Deliverables.Add(deliverable);
            context.SaveChanges();
        }

        public void UpdateDeliverable(Deliverable deliverable)
        {
            context.Deliverables.Update(deliverable);
            context.SaveChanges();
        }
    }
}
