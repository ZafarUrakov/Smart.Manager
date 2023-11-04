//===========================
// Copyright (c) Tarteeb LLC
// Managre quickly and easy
//===========================

using SmartManager.Models.Attendances;
using SmartManager.Models.Groups;
using SmartManager.Models.Payments;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SmartManager.Models.Students
{
    public class Student
    {
        public Guid Id { get; set; }
        public string GivenName { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public Gender Gender { get; set; }

        public string GroupName { get; set; }
        public Guid GroupId { get; set; }

        [JsonIgnore]
        public IEnumerable<Attendance> Attendances { get; set; }
        public IEnumerable<Payment> Payments { get; set; }
    }
}
