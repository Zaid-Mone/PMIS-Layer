using PMISBussinessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PMISBussinessLayer.Repositories
{
   public interface IPaymentTermRepository
    {
        public List<PaymentTerm> GetAllPaymentTerm();
        public void InsertPaymentTerm(PaymentTerm PaymentTerm);
        public void UpdatePaymentTerm(PaymentTerm PaymentTerm);
        public void DeletePaymentTerm(PaymentTerm PaymentTerm);
        public PaymentTerm GetPaymentTerm(int Id);
    }
}


