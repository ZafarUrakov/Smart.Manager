//===========================
// Copyright (c) Tarteeb LLC
// Managre quickly and easy
//===========================

using SmartManager.Models.Statistics;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace SmartManager.Services.Foundations.Statistics
{
    public interface IStatisticService
    {
        ValueTask<Statistic> AddStatisticAsync(Statistic statistic);
        ValueTask<Statistic> RetrieveStatisticByIdAsync(Guid statisticid);
        IQueryable<Statistic> RetrieveAllStatistics();
        ValueTask<Statistic> ModifyStatisticAsync(Statistic statistic);
        ValueTask<Statistic> RemoveStatisticAsync(Guid statisticId);
    }
}
