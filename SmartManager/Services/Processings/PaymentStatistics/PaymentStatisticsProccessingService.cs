//===========================
// Copyright (c) Tarteeb LLC
// Managre quickly and easy
//===========================

using SmartManager.Models.Payments;
using SmartManager.Services.Foundations.Payments;
using System.Linq;
using System.Threading.Tasks;
using System;
using SmartManager.Services.Foundations.PaymentStatistics;
using SmartManager.Models.PaymentStatistics;

namespace SmartManager.Services.Processings.PaymentStatistics
{
    public class PaymentStatisticsProccessingService : IPaymentStatisticsProccessingServic
    {
        private readonly IPaymentStatisticService PaymentStatisticService;

        public PaymentStatisticsProccessingService(IPaymentStatisticService PaymentStatisticService)
        {
            this.PaymentStatisticService = PaymentStatisticService;
        }
        public async ValueTask<PaymentStatistic> AddPaymentStatisticAsync(PaymentStatistic paymentStatistic) =>
           await this.PaymentStatisticService.AddPaymentStatisticAsync(paymentStatistic);

        public async ValueTask<PaymentStatistic> RetrievePaymentStatisticByIdAsync(Guid paymentStatisticid) =>
            await this.PaymentStatisticService.RetrievePaymentStatisticByIdAsync(paymentStatisticid);

        public IQueryable<PaymentStatistic> RetrieveAllPaymentStatistics() =>
            this.PaymentStatisticService.RetrieveAllPaymentStatistics();

        public async ValueTask<PaymentStatistic> ModifyPaymentStatisticAsync(PaymentStatistic paymentStatistic) =>
            await this.PaymentStatisticService.ModifyPaymentStatisticAsync(paymentStatistic);

        public async ValueTask<PaymentStatistic> RemovePaymentStatisticAsync(Guid paymentStatisticid) =>
            await this.PaymentStatisticService.RemovePaymentStatisticAsync(paymentStatisticid);
    }
}
