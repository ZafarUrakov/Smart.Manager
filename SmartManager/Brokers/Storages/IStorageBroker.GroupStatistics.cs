using System.Linq;
using System.Threading.Tasks;
using System;
using SmartManager.Models.GroupStatistics;

namespace SmartManager.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        ValueTask<GroupStatistic> InsertGroupStatisticAsync(GroupStatistic groupStatistic);
        IQueryable<GroupStatistic> SelectAllGroupStatistics();
        ValueTask<GroupStatistic> SelectGroupStatisticByIdAsync(Guid groupStatisticId);
        ValueTask<GroupStatistic> UpdateGroupStatisticAsync(GroupStatistic groupStatistic);
        ValueTask<GroupStatistic> DeleteGroupStatisticAsync(GroupStatistic groupStatistic);
    }
}
