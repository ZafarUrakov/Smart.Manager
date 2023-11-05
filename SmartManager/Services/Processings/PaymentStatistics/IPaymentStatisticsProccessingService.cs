//===========================
// Copyright (c) Tarteeb LLC
// Managre quickly and easy
//===========================

using SmartManager.Models.Payments;
using System.Linq;
using System.Threading.Tasks;
using System;
using SmartManager.Models.PaymentStatistics;
using SmartManager.Models.Groups;
using SmartManager.Models.Students;

namespace SmartManager.Services.Processings.PaymentStatistics
{
    public interface IPaymentStatisticsProccessingService
    {
        ValueTask<PaymentStatistic> AddPaymentStatisticAsync(Student student);
        ValueTask<PaymentStatistic> RetrievePaymentStatisticByIdAsync(Guid paymentStatisticId);
        IQueryable<PaymentStatistic> RetrieveAllPaymentStatistics();
        ValueTask<PaymentStatistic> ModifyPaymentStatisticAsync(PaymentStatistic paymentStatistic);
        ValueTask<PaymentStatistic> RemovePaymentStatisticAsync(Guid paymentStatisticId);
    }
}
