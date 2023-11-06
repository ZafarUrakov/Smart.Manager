//===========================
// Copyright (c) Tarteeb LLC
// Managre quickly and easy
//===========================

using SmartManager.Brokers.Storages;
using SmartManager.Models.Groups;
using SmartManager.Models.PaymentStatistics;
using SmartManager.Models.Students;
using SmartManager.Services.Foundations.PaymentStatistics;
using SmartManager.Services.Processings.Groups;
using SmartManager.Services.Processings.Payments;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SmartManager.Services.Processings.PaymentStatistics
{
    public class PaymentStatisticsProccessingService : IPaymentStatisticsProccessingService
    {
        private readonly IPaymentStatisticService paymentStatisticService;
        private readonly IGroupProcessingService groupProcessingService;
        private readonly IPaymentProcessingService paymentProcessingService;
        private readonly IStorageBroker storageBroker;

        public PaymentStatisticsProccessingService(
            IPaymentStatisticService PaymentStatisticService,
            IGroupProcessingService groupProcessingService,
            IPaymentProcessingService paymentProcessingService,
            IStorageBroker storageBroker)
        {
            this.paymentStatisticService = PaymentStatisticService;
            this.groupProcessingService = groupProcessingService;
            this.paymentProcessingService = paymentProcessingService;
            this.storageBroker = storageBroker;
        }
        public async ValueTask<PaymentStatistic> AddPaymentStatisticAsync(Student student)
        {
            var students = this.storageBroker.SelectAllStudents();
            var group = await this.groupProcessingService.RetrieveGroupByIdAsync(student.GroupId);

            int totalStudents = 0;
            int paids = 0;

            TotalCountStudentsAndPayments(student, students, ref totalStudents, ref paids);

            var paymentStatistic = this.paymentStatisticService
                .RetrieveAllPaymentStatistics().FirstOrDefault(p => p.GroupId == group.Id);

            if (paymentStatistic is null)
            {
                PaymentStatistic newPaymentStatistic = AddPaymentStatisticIfNotFound(group);

                newPaymentStatistic.PaidPercentage = (paids / totalStudents) * 100;
                newPaymentStatistic.NotPaidPercentage = 100 - newPaymentStatistic.PaidPercentage;

                return await this.paymentStatisticService.AddPaymentStatisticAsync(newPaymentStatistic);
            }
            else
            {
                paymentStatistic.PaidPercentage = (paids / totalStudents) * 100;
                paymentStatistic.NotPaidPercentage = 100 - paymentStatistic.PaidPercentage;

                return await this.paymentStatisticService.ModifyPaymentStatisticAsync(paymentStatistic);
            }
        }

        private void TotalCountStudentsAndPayments(
            Student student, IQueryable<Student> students, ref int totalStudents, ref int paids)
        {
            var payments = this.paymentProcessingService.RetrieveAllPayments();

            foreach (var item in students)
            {

                foreach (var payment in payments)
                {
                    if (payment.IsPaid == true)
                        paids++;
                }

                totalStudents++;
            }
        }

        private static PaymentStatistic AddPaymentStatisticIfNotFound(Group group)
        {
            return new PaymentStatistic
            {
                Id = Guid.NewGuid(),
                Group = group,
                GroupId = group.Id
            };
        }

        public async ValueTask<PaymentStatistic> RetrievePaymentStatisticByIdAsync(Guid paymentStatisticid) =>
            await this.paymentStatisticService.RetrievePaymentStatisticByIdAsync(paymentStatisticid);

        public IQueryable<PaymentStatistic> RetrieveAllPaymentStatistics() =>
            this.paymentStatisticService.RetrieveAllPaymentStatistics();

        public async ValueTask<PaymentStatistic> ModifyPaymentStatisticAsync(PaymentStatistic paymentStatistic) =>
            await this.paymentStatisticService.ModifyPaymentStatisticAsync(paymentStatistic);

        public async ValueTask<PaymentStatistic> RemovePaymentStatisticAsync(Guid paymentStatisticid) =>
            await this.paymentStatisticService.RemovePaymentStatisticAsync(paymentStatisticid);
    }
}
