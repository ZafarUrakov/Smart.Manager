//===========================
// Copyright (c) Tarteeb LLC
// Managre quickly and easy
//===========================

using SmartManager.Models.Groups;
using SmartManager.Models.PaymentStatistics;
using SmartManager.Models.Students;
using SmartManager.Services.Foundations.PaymentStatistics;
using SmartManager.Services.Processings.Groups;
using SmartManager.Services.Processings.Payments;
using SmartManager.Services.Processings.Students;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SmartManager.Services.Processings.PaymentStatistics
{
    public class PaymentStatisticsProccessingService : IPaymentStatisticsProccessingService
    {
        private readonly IPaymentStatisticService paymentStatisticService;
        private readonly IGroupProcessingService groupProcessingService;
        private readonly IStudentProcessingService studentProcessingService;
        private readonly IPaymentProcessingService paymentProcessingService;

        public PaymentStatisticsProccessingService(
            IPaymentStatisticService PaymentStatisticService,
            IGroupProcessingService groupProcessingService,
            IPaymentProcessingService paymentProcessingService)
        {
            this.paymentStatisticService = PaymentStatisticService;
            this.groupProcessingService = groupProcessingService;
            this.paymentProcessingService = paymentProcessingService;
        }
        public async ValueTask<PaymentStatistic> AddPaymentStatisticAsync(Student student)
        {
            var group = await this.groupProcessingService.RetrieveGroupByIdAsync(student.GroupId);

            IQueryable<Student> students = this.studentProcessingService.RetrieveAllStudents();

            int totalStudents = 0;
            int paids = 0;

            TotalCountStudentsAndPayments(student, students, ref totalStudents, ref paids);

            var paymentStatistic = this.paymentStatisticService
                .RetrieveAllPaymentStatistics().FirstOrDefault(p => p.GroupId == group.Id);

            if (paymentStatistic is null)
            {
                PaymentStatistic newPaymentStatistic = AddPaymentStatisticIfNotFound(group);

                paymentStatistic.PaidPercentage = (paids / totalStudents) * 100;
                paymentStatistic.NotPaidPercentage = 100 - paymentStatistic.PaidPercentage;

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
