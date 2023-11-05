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
using SmartManager.Models.Students;
using System.Collections.Generic;

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

        public async ValueTask<GroupStatistic> UpdateStatisticsByStudentAsync(Student student)
        {
            GroupStatistic groupStatistic =
                (GroupStatistic)this.groupStatisticService
                .RetrieveAllGroupStatistics().FirstOrDefault(s => s.GroupId == student.GroupId);

            if (groupStatistic == null)
            {
                return await AddNewStatisticAsync(student);
            }

            if (student.Gender == Gender.Male)
            {
                groupStatistic.MaleStudents++;
                return await ModifyGroupStatisticAsync(groupStatistic);
            }
            else
            {
                groupStatistic.FemaleStudents++;
                return await ModifyGroupStatisticAsync(groupStatistic);
            }
        }

        public async ValueTask<GroupStatistic> AddNewStatisticAsync(Student student)
        {
            GroupStatistic groupStatistic = new GroupStatistic();
            groupStatistic.GroupId = student.GroupId;

            if (student.Gender == Gender.Male)
            {
                groupStatistic.MaleStudents += 1;
                return await AddGroupStatisticAsync(groupStatistic);
            }
            else
            {
                groupStatistic.FemaleStudents += 1;
                return await AddGroupStatisticAsync(groupStatistic);

            }
        }

        public async Task CheckStatisticOfList(List<Student> students)
        {
            foreach (var item in students)
            {
                await UpdateStatisticsByStudentAsync(item);
            }
        }
    }
}

