using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using PMISBussinessLayer.Data;
using PMISBussinessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PMISBussinessLayer.Repositories
{
   
    public class PaymentTermRepository : IPaymentTermRepository
    {

        private readonly ApplicationDbContext context;
        public PaymentTermRepository(ApplicationDbContext context)
        {
            this.context = context;

        }
        void IPaymentTermRepository.DeletePaymentTerm(PaymentTerm PaymentTerm)
        {

            context.PaymentTerms.Remove(PaymentTerm);
            context.SaveChanges();

        }

        List<PaymentTerm> IPaymentTermRepository.GetAllPaymentTerm()
        {
            return context.PaymentTerms
               .Include(p => p.Deliverable)
               .ToList();
        }

      public  PaymentTerm GetPaymentTerm(int Id)
        {
            return context.PaymentTerms.SingleOrDefault(x => x.Id == Id);
        }

       public void InsertPaymentTerm(PaymentTerm PaymentTerm)
        {
            context.PaymentTerms.Add(PaymentTerm);
            context.SaveChanges();
        }

      public  void UpdatePaymentTerm(PaymentTerm PaymentTerm)
        {
            context.PaymentTerms.Update(PaymentTerm);
            context.SaveChanges(); 
        }
    }
}
