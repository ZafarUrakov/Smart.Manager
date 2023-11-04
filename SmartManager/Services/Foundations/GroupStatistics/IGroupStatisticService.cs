//===========================
// Copyright (c) Tarteeb LLC
// Managre quickly and easy
//===========================

using SmartManager.Models.Payments;
using System.Linq;
using System.Threading.Tasks;
using System;
using SmartManager.Models.GroupStatistics;

namespace SmartManager.Services.Foundations.GroupStatistics
{
    public interface IGroupStatisticService
    {
        ValueTask<GroupStatistic> AddGroupStatisticAsync(GroupStatistic groupStatistic);
        ValueTask<GroupStatistic> RetrieveGroupStatisticByIdAsync(Guid groupStatisticId);
        IQueryable<GroupStatistic> RetrieveAllGroupStatistics();
        ValueTask<GroupStatistic> ModifyGroupStatisticAsync(GroupStatistic groupStatistic);
        ValueTask<GroupStatistic> RemoveGroupStatisticAsync(Guid groupStatisticId);
    }
}
