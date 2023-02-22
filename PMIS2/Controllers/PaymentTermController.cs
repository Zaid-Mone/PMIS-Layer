using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    [Authorize]
    public class PaymentTermController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IPaymentTermRepository paymentTermRepository;
        private readonly IDeliverableRepository deliverableRepository;
        private readonly IProjectRepository projectRepository;
      
        private readonly IProjectPhaseRepository projectPhaseRepository;
        public PaymentTermController(ApplicationDbContext context, IPaymentTermRepository paymentTermRepository,
            IDeliverableRepository deliverableRepository, IProjectRepository projectRepository, IProjectPhaseRepository projectPhaseRepository)
        {
           this.context = context;
            this.paymentTermRepository = paymentTermRepository;
            this.deliverableRepository = deliverableRepository;
            this.projectRepository = projectRepository;
        }
        public IActionResult Index()
        {
            return View(paymentTermRepository.GetAllPaymentTerm());
        }
        public IActionResult Create( int id)
        {
            var a = projectRepository.GetAllProject();
            ViewBag.project = a;
            // all projectstatus

            var d = deliverableRepository.GetAllDeliverable();
            ViewBag.ProjectPhase = d;
            // all phases
            var Di = deliverableRepository.GetDeliverable(id);
            ViewBag.Deliverable = Di;
          

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(InsertPaymentTermDTO InsertPaymentTermDTO)
        {
            if (ModelState.IsValid)
            {

                var paymentTerm = new PaymentTerm()
                {
                    PaymentTermTitle = InsertPaymentTermDTO.PaymentTermTitle,
                    PaymentTermAmount = InsertPaymentTermDTO.PaymentTermAmount,
                    DeliverableId = InsertPaymentTermDTO.DeliverableId,


                };
                paymentTermRepository.InsertPaymentTerm(paymentTerm);
                return RedirectToAction(nameof(Index));
            }

            return View(InsertPaymentTermDTO);
        }

        public IActionResult Edit(int id)
        {

            var paymentTerm = paymentTermRepository.GetPaymentTerm(id);
            ViewBag.PaymentTerm = paymentTerm;
            var D = deliverableRepository.GetDeliverable(paymentTerm.DeliverableId);
            ViewBag.Deliverable = D;

            if (paymentTerm == null)
            {
                return NotFound();
            }

            return View(paymentTerm);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paymentTerm = await context.PaymentTerms
                .Include(p => p.Deliverable)
                .FirstOrDefaultAsync(m => m.Id == id);
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
