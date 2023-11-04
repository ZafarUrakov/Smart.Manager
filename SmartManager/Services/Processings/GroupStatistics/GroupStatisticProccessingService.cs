//===========================
// Copyright (c) Tarteeb LLC
// Managre quickly and easy
//===========================

using SmartManager.Models.Payments;
using SmartManager.Services.Foundations.Payments;
using System.Linq;
using System.Threading.Tasks;
using System;
using SmartManager.Services.Foundations.GroupStatistics;
using SmartManager.Models.GroupStatistics;

namespace SmartManager.Services.Processings.GroupStatistics
{
    public class GroupStatisticProccessingService : IGroupStatisticProccessingService
    {
        private readonly IGroupStatisticService groupStatisticService;

        public GroupStatisticProccessingService(IGroupStatisticService groupStatisticService)
        {
            this.groupStatisticService = groupStatisticService;
        }
        public async ValueTask<GroupStatistic> AddGroupStatisticAsync(GroupStatistic GroupStatistic) =>
           await this.groupStatisticService.AddGroupStatisticAsync(GroupStatistic);

        public async ValueTask<GroupStatistic> RetrieveGroupStatisticByIdAsync(Guid GroupStatisticid) =>
            await this.groupStatisticService.RetrieveGroupStatisticByIdAsync(GroupStatisticid);

        public IQueryable<GroupStatistic> RetrieveAllGroupStatistics() =>
            this.groupStatisticService.RetrieveAllGroupStatistics();

        public async ValueTask<GroupStatistic> ModifyGroupStatisticAsync(GroupStatistic GroupStatistic) =>
            await this.groupStatisticService.ModifyGroupStatisticAsync(GroupStatistic);

        public async ValueTask<GroupStatistic> RemoveGroupStatisticAsync(Guid GroupStatisticid) =>
            await this.groupStatisticService.RemoveGroupStatisticAsync(GroupStatisticid);
    }
}

