using SmartManager.Models.Payments;
using System.Linq;
using System.Threading.Tasks;
using System;
using SmartManager.Models.GroupStatistics;
using SmartManager.Models.Students;
using System.Collections.Generic;

namespace SmartManager.Services.Processings.GroupStatistics
{
    public interface IGroupStatisticProccessingService
    {
        ValueTask<GroupStatistic> AddGroupStatisticAsync(GroupStatistic groupStatistic);
        ValueTask<GroupStatistic> RetrieveGroupStatisticByIdAsync(Guid groupStatisticId);
        IQueryable<GroupStatistic> RetrieveAllGroupStatistics();
        ValueTask<GroupStatistic> ModifyGroupStatisticAsync(GroupStatistic groupStatistic);
        ValueTask<GroupStatistic> RemoveGroupStatisticAsync(Guid groupStatisticId);
        ValueTask<GroupStatistic> UpdateStatisticsByStudentAsync(Student student);
        Task CheckStatisticOfList(List<Student> students);
    }
}
