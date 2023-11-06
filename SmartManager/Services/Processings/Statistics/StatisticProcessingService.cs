//===========================
// Copyright (c) Tarteeb LLC
// Managre quickly and easy
//===========================

using SmartManager.Models.Statistics;
using SmartManager.Services.Foundations.Statistics;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SmartManager.Services.Processings.Statistics
{
    public class StatisticProcessingService : IStatisticProcessingService
    {
        private readonly IStatisticService statisticService;

        public StatisticProcessingService(IStatisticService statisticService)
        {
            this.statisticService = statisticService;
        }
        public async ValueTask<Statistic> AddStatisticAsync(Statistic Statistic) =>
           await this.statisticService.AddStatisticAsync(Statistic);

        public async ValueTask<Statistic> RetrieveStatisticByIdAsync(Guid Statisticid) =>
            await this.statisticService.RetrieveStatisticByIdAsync(Statisticid);

        public IQueryable<Statistic> RetrieveAllStatistics() =>
            this.statisticService.RetrieveAllStatistics();

        public async ValueTask<Statistic> ModifyStatisticAsync(Statistic Statistic) =>
            await this.statisticService.ModifyStatisticAsync(Statistic);

        public async ValueTask<Statistic> RemoveStatisticAsync(Guid Statisticid) =>
            await this.statisticService.RemoveStatisticAsync(Statisticid);
    }
}
