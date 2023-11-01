//===========================
// Copyright (c) Tarteeb LLC
// Managre quickly and easy
//===========================

using System.Linq;
using System.Threading.Tasks;
using System;
using SmartManager.Models.Attendances;

namespace SmartManager.Services.Foundations.Attendances
{
    public interface IAttendanceService
    {
        ValueTask<Attendance> AddAttendanceAsync(Attendance attendance);
        ValueTask<Attendance> RetrieveAttendanceByIdAsync(Guid attendanceid);
        IQueryable<Attendance> RetrieveAllAttendances();
        ValueTask<Attendance> ModifyAttendanceAsync(Attendance attendance);
        ValueTask<Attendance> RemoveAttendanceAsync(Guid attendanceId);
    }
}
