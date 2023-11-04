//===========================
// Copyright (c) Tarteeb LLC
// Managre quickly and easy
//===========================

using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using System;
using SmartManager.Models.GroupStatistics;

namespace SmartManager.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<GroupStatistic> GroupStatistics { get; set; }

        public async ValueTask<GroupStatistic> InsertGroupStatisticAsync(GroupStatistic groupStatistic) =>
           await InsertAsync(groupStatistic);

        public IQueryable<GroupStatistic> SelectAllGroupStatistics() =>
            SelectAll<GroupStatistic>().AsQueryable();

        public async ValueTask<GroupStatistic> SelectGroupStatisticByIdAsync(Guid groupStatisticId) =>
            await SelectAsync<GroupStatistic>(groupStatisticId);

        public async ValueTask<GroupStatistic> UpdateGroupStatisticAsync(GroupStatistic groupStatistic) =>
            await UpdateAsync(groupStatistic);

        public async ValueTask<GroupStatistic> DeleteGroupStatisticAsync(GroupStatistic groupStatistic) =>
            await DeleteAsync(groupStatistic);
    }
}
