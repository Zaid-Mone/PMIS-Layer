using Microsoft.AspNetCore.Mvc;
using PMIS2.DTO;
using PMISBussinessLayer.Data;
using PMISBussinessLayer.Entities;
using PMISBussinessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PMIS2.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly ApplicationDbContext _context;
   private readonly InvoiceRepository invoiceRepository;
        private readonly IProjectRepository projectRepository;
        private readonly IPaymentTermRepository paymentTermRepository;
        private readonly IDeliverableRepository deliverableRepository;

        public InvoiceController(ApplicationDbContext context, IPaymentTermRepository paymentTermRepository
           , IProjectRepository projectRepository , InvoiceRepository invoiceRepository, IDeliverableRepository deliverableRepository)
        {
            _context = context;
         
            this.projectRepository = projectRepository;
            this.invoiceRepository = invoiceRepository;
            this.paymentTermRepository = paymentTermRepository;
            this.deliverableRepository = deliverableRepository;

        }
        public IActionResult Index()
        {
            return View(invoiceRepository.GetAllInvoices());
        }
        public IActionResult Create(int id)
        {
            var a = projectRepository.GetAllProject();
            ViewBag.project = a;
         

            var d = invoiceRepository.GetAllInvoices();
            ViewBag.ProjectPhase = d;
          

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(InsertInvoiceDTO inserInvoiceDTO)
        {
            if (ModelState.IsValid)
            {

                return RedirectToAction(nameof(Index));
            }

            return View(inserInvoiceDTO);
        }

        public IActionResult Edit(int id)
        {

            var Invoice = invoiceRepository.GetInvoice(id);
            ViewBag.Invoice = Invoice;
         
            if (Invoice == null)
            {
                return NotFound();
            }

            return View(Invoice);
        }

        public IActionResult Delete(int id)
        {
            var paymentTerm = paymentTermRepository.GetPaymentTerm(id);
            if (paymentTerm == null)
            {
                return NotFound();
            }
            return View(paymentTerm);
        }



        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var PaymentTerm = paymentTermRepository.GetPaymentTerm(id);

            paymentTermRepository.DeletePaymentTerm(PaymentTerm);
            return RedirectToAction(nameof(Index));
        }
    }
}
