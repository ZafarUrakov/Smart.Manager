//===========================
// Copyright (c) Tarteeb LLC
// Managre quickly and easy
//===========================

using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SmartManager.Models.Payments;
using SmartManager.Services.Processings.Payments;
using SmartManager.Services.Processings.Students;

namespace SmartManager.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IPaymentProcessingService paymentProcessingService;
        private readonly IStudentProcessingService studentProcessingService;

        public PaymentController(
            IPaymentProcessingService paymentProcessingService,
            IStudentProcessingService studentProcessingService)
        {
            this.paymentProcessingService = paymentProcessingService;
            this.studentProcessingService = studentProcessingService;
        }
        [HttpPost]
        public async ValueTask<ActionResult> UpdatePaymentAsync(Guid studentId, bool isPayed)
        {
            var student =
                this.studentProcessingService.RetrieveStudentByIdAsync(studentId);

            var payment = new Payment
            {
                Id = Guid.NewGuid(),
                Amount = 900000,
                Date = DateTime.Now,
                IsPaid = isPayed
            };

            await this.paymentProcessingService.AddPaymentAsync(payment);

            return RedirectToAction("GetPayment", "Student");
        }

        [HttpPost]
        public async ValueTask<ActionResult> PostPayment([FromForm] Payment payment)
        {
            await this.paymentProcessingService.AddPaymentAsync(payment);

            return RedirectToAction("GetPayment", "Student");
        }
    }
}
