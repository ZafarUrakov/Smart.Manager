//===========================
// Copyright (c) Tarteeb LLC
// Managre quickly and easy
//===========================

using SmartManager.Models.Groups;
using SmartManager.Models.GroupsStatistics;
using SmartManager.Services.Foundations.GroupsStatistics;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SmartManager.Services.Processings.GroupsStatistics
{
    public class GroupsStatisticProccessingService : IGroupsStatisticProccessingService
    {
        private readonly IGroupsStatisticService groupsStatisticService;

        public GroupsStatisticProccessingService(IGroupsStatisticService groupsStatisticService)
        {
            this.groupsStatisticService = groupsStatisticService;
        }
        public async ValueTask<GroupsStatistic> AddGroupsStatisticAsync(Group group)
        {
            throw new NotImplementedException();
        }

        public async ValueTask<GroupsStatistic> RetrieveGroupsStatisticByIdAsync(Guid groupsStatisticid) =>
            await this.groupsStatisticService.RetrieveGroupsStatisticByIdAsync(groupsStatisticid);

        public IQueryable<GroupsStatistic> RetrieveAllGroupsStatistics() =>
            this.groupsStatisticService.RetrieveAllGroupsStatistics();

        public async ValueTask<GroupsStatistic> ModifyGroupsStatisticAsync(GroupsStatistic groupsStatistic) =>
            await this.groupsStatisticService.ModifyGroupsStatisticAsync(groupsStatistic);

        public async ValueTask<GroupsStatistic> RemoveGroupsStatisticAsync(Guid groupsStatisticid) =>
            await this.groupsStatisticService.RemoveGroupsStatisticAsync(groupsStatisticid);
    }
}

