//===========================
// Copyright (c) Tarteeb LLC
// Managre quickly and easy
//===========================

using System;
using System.Collections.Generic;
using SmartManager.Models.Groups;

namespace SmartManager.Models.GroupStatistics
{
    public class GroupStatistic
    {
        public Guid Id { get; set; }
        public int MaleStudents { get; set; }
        public int FemaleStudents { get; set; }
        public Guid GroupId { get; set; }
        public Group Group { get; set; }
    }
}
