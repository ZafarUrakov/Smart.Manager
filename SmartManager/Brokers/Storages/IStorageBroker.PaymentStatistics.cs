//===========================
// Copyright (c) Tarteeb LLC
// Managre quickly and easy
//===========================

using SmartManager.Models.Payments;
using System.Linq;
using System.Threading.Tasks;
using System;
using SmartManager.Models.PaymentStatistics;

namespace SmartManager.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        ValueTask<PaymentStatistic> InsertPaymentStatisticAsync(PaymentStatistic paymentStatistic);
        IQueryable<PaymentStatistic> SelectAllPaymentStatistics();
        ValueTask<PaymentStatistic> SelectPaymentStatisticByIdAsync(Guid paymentStatisticId);
        ValueTask<PaymentStatistic> UpdatePaymentStatisticAsync(PaymentStatistic paymentStatistic);
        ValueTask<PaymentStatistic> DeletePaymentStatisticAsync(PaymentStatistic paymentStatistic);
    }
}
