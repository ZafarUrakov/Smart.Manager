//===========================
// Copyright (c) Tarteeb LLC
// Managre quickly and easy
//===========================

using SmartManager.Brokers.Storages;
using System.Linq;
using System.Threading.Tasks;
using System;
using SmartManager.Models.GroupStatistics;

namespace SmartManager.Services.Foundations.GroupStatistics
{
    public class GroupStatisticService : IGroupStatisticService
    {
        private readonly IStorageBroker storageBroker;

        public GroupStatisticService(IStorageBroker storageBroker)
        {
            this.storageBroker = storageBroker;
        }

        public async ValueTask<GroupStatistic> AddGroupStatisticAsync(GroupStatistic groupStatistic) =>
            await this.storageBroker.InsertGroupStatisticAsync(groupStatistic);

        public async ValueTask<GroupStatistic> RetrieveGroupStatisticByIdAsync(Guid groupStatisticId) =>
            await this.storageBroker.SelectGroupStatisticByIdAsync(groupStatisticId);

        public IQueryable<GroupStatistic> RetrieveAllGroupStatistics() =>
            this.storageBroker.SelectAllGroupStatistics();

        public async ValueTask<GroupStatistic> ModifyGroupStatisticAsync(GroupStatistic groupStatistic) =>
            await this.storageBroker.UpdateGroupStatisticAsync(groupStatistic);

        public async ValueTask<GroupStatistic> RemoveGroupStatisticAsync(Guid groupStatisticId)
        {
            GroupStatistic groupStatistic =
                await this.storageBroker.SelectGroupStatisticByIdAsync(groupStatisticId);

            return await this.storageBroker.DeleteGroupStatisticAsync(groupStatistic);
        }
    }
}
