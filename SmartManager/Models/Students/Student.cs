//===========================
// Copyright (c) Tarteeb LLC
// Managre quickly and easy
//===========================

using SmartManager.Models.Attendances;
using SmartManager.Models.Groups;
using SmartManager.Models.Payments;
using System;

namespace SmartManager.Models.Students
{
    public class Student
    {
        public Guid Id { get; set; }
        public string GivenName { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public Gender Gender { get; set; }
        public Group Group { get; set; }
        public Attendance Attendance { get; set; }
        public Payment Payment { get; set; }
    }
}
