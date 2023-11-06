//===========================
// Copyright (c) Tarteeb LLC
// Managre quickly and easy
//===========================

using SmartManager.Models.Groups;
using SmartManager.Models.GroupsStatistics;
using SmartManager.Models.Students;
using SmartManager.Services.Foundations.GroupsStatistics;
using SmartManager.Services.Processings.Students;
using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace SmartManager.Services.Processings.GroupsStatistics
{
    public class GroupsStatisticProccessingService : IGroupsStatisticProccessingService
    {
        private readonly IGroupsStatisticService groupsStatisticService;
        private readonly IStudentProcessingService studentProcessingService;

        public GroupsStatisticProccessingService(
            IGroupsStatisticService groupsStatisticService,
            IStudentProcessingService studentProcessingService)
        {
            this.groupsStatisticService = groupsStatisticService;
            this.studentProcessingService = studentProcessingService;
        }
        public async ValueTask<GroupsStatistic> AddGroupsStatisticAsync(Group group)
        {
            var students = this.studentProcessingService.RetrieveAllStudents();
            var studentsWithGroup = this.studentProcessingService
                .RetrieveAllStudents().Where(s => s.GroupId == group.Id);

            decimal studentsCount = students.Count();
            decimal studentsCountWithGroup = studentsWithGroup.Count();

            decimal studentsPercentageWithGroup = (studentsCountWithGroup / studentsCount) * 100;

            var groupsStatistic = this.groupsStatisticService
                .RetrieveAllGroupsStatistics().FirstOrDefault(g => g.Name == group.GroupName);

            if (groupsStatistic is null)
            {
                GroupsStatistic newGroupsStatistic = new GroupsStatistic
                {
                    Id = Guid.NewGuid(),
                    Name = group.GroupName,
                    Percentage = studentsPercentageWithGroup,
                    GroupId = group.Id,
                };

                return await this.groupsStatisticService.AddGroupsStatisticAsync(newGroupsStatistic);
            }
            else
            {
                groupsStatistic.Percentage = studentsPercentageWithGroup;

                return await this.groupsStatisticService.ModifyGroupsStatisticAsync(groupsStatistic);
            }
        }

        public async ValueTask<GroupsStatistic> AddGroupsStatisticsWithStudentsAsync(Student student)
        {
            var students = this.studentProcessingService.RetrieveAllStudents();
            var studentsWithGroup = this.studentProcessingService
                .RetrieveAllStudents().Where(s => s.GroupName == student.GroupName);

            decimal studentsCount = students.Count();
            decimal studentsCountWithGroup = studentsWithGroup.Count();

            decimal studentsPercentageWithGroup = (studentsCountWithGroup / studentsCount) * 100;

            var groupsStatistic = this.groupsStatisticService
                .RetrieveAllGroupsStatistics().FirstOrDefault(g => g.Name == student.GroupName);

            if (groupsStatistic is null)
            {
                GroupsStatistic newGroupsStatistic = new GroupsStatistic
                {
                    Id = Guid.NewGuid(),
                    Name = student.GroupName,
                    Percentage = studentsPercentageWithGroup,
                    GroupId = student.GroupId
                };

                await this.groupsStatisticService.AddGroupsStatisticAsync(newGroupsStatistic);

                await UpdateOtherGroupsStatistics();

                return newGroupsStatistic;
            }
            else
            {
                groupsStatistic.Percentage = studentsPercentageWithGroup;

                await this.groupsStatisticService.ModifyGroupsStatisticAsync(groupsStatistic);

                await UpdateOtherGroupsStatistics();

                return groupsStatistic;
            }
        }

        private async Task UpdateOtherGroupsStatistics()
        {
            var updatedStudents = this.studentProcessingService.RetrieveAllStudents();

            foreach (var updateStudent in updatedStudents)
            {
                var updatedStudenstWithGroup = this.studentProcessingService
                    .RetrieveAllStudents().Where(s => s.GroupName == updateStudent.GroupName);

                decimal updatedStudentsCount = updatedStudents.Count();
                decimal updatedStudensCounttWithGroup = updatedStudenstWithGroup.Count();

                decimal updatedStudentsPercentageWithGroup = (updatedStudensCounttWithGroup / updatedStudentsCount) * 100;

                var updatedGroupsStatistic = this.groupsStatisticService
                    .RetrieveAllGroupsStatistics().FirstOrDefault(g => g.Name == updateStudent.GroupName);

                updatedGroupsStatistic.Percentage = updatedStudentsPercentageWithGroup;

                await this.groupsStatisticService.ModifyGroupsStatisticAsync(updatedGroupsStatistic);
            }
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

