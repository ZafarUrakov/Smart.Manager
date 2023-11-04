//===========================
// Copyright (c) Tarteeb LLC
// Managre quickly and easy
//===========================

using SmartManager.Models.Groups;
using System;
using System.Reflection.Metadata.Ecma335;

namespace SmartManager.Models.PaymentStatistics
{
    public class PaymentStatistics
    {
        Guid Id { get; set; }
        public decimal PaidPercentage { get; set; }
        public decimal NotPaidPercentage { get; set; }
        public Group Group { get; set; }
    }
}
