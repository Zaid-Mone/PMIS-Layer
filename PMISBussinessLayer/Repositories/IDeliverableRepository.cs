using PMISBussinessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PMISBussinessLayer.Repositories
{
   public interface IDeliverableRepository
    {
        public List<Deliverable> GetAllDeliverable();
        public void InsertDeliverable(Deliverable deliverable);
        public void UpdateDeliverable(Deliverable deliverable);
        public void DeleteDeliverable(Deliverable deliverable);
        public Deliverable GetDeliverable(int deliverableid);
    }
}
