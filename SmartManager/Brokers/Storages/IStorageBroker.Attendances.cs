//===========================
// Copyright (c) Tarteeb LLC
// Managre quickly and easy
//===========================

using System.Linq;
using System.Threading.Tasks;
using System;
using SmartManager.Models.Attendances;

namespace SmartManager.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        ValueTask<Attendance> InsertAttendanceAsync(Attendance attendance);
        IQueryable<Attendance> SelectAllAttendances();
        ValueTask<Attendance> SelectAttendanceByIdAsync(Guid attendanceId);
        ValueTask<Attendance> UpdateAttendanceAsync(Attendance attendance);
        ValueTask<Attendance> DeleteAttendanceAsync(Attendance attendance);
    }
}
