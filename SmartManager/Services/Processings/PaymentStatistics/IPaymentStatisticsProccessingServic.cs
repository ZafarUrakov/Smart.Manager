//===========================
// Copyright (c) Tarteeb LLC
// Managre quickly and easy
//===========================

using SmartManager.Models.Payments;
using System.Linq;
using System.Threading.Tasks;
using System;
using SmartManager.Models.PaymentStatistics;

namespace SmartManager.Services.Processings.PaymentStatistics
{
    public interface IPaymentStatisticsProccessingServic
    {
        ValueTask<PaymentStatistic> AddPaymentStatisticAsync(PaymentStatistic paymentStatistic);
        ValueTask<PaymentStatistic> RetrievePaymentStatisticByIdAsync(Guid paymentStatisticId);
        IQueryable<PaymentStatistic> RetrieveAllPaymentStatistics();
        ValueTask<PaymentStatistic> ModifyPaymentStatisticAsync(PaymentStatistic paymentStatistic);
        ValueTask<PaymentStatistic> RemovePaymentStatisticAsync(Guid paymentStatisticId);
    }
}
