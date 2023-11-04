//===========================
// Copyright (c) Tarteeb LLC
// Managre quickly and easy
//===========================

using SmartManager.Models.GroupStatistics;
using SmartManager.Models.PaymentStatistics;
using SmartManager.Models.Students;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SmartManager.Models.Groups
{
    public class Group
    {
        public Guid Id { get; set; }
        public string GroupName { get; set; }
        [JsonIgnore]
        public IEnumerable<Student> Students { get; set; }
        public IEnumerable<GroupStatistic> GroupStatistics { get; set; }
        public IEnumerable<PaymentStatistic> PaymentStatistics { get; set; }
    }
}
