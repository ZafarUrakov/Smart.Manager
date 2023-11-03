//===========================
// Copyright (c) Tarteeb LLC
// Managre quickly and easy
//===========================

using System.Linq;
using System.Threading.Tasks;
using System;
using SmartManager.Models.Bots;

namespace SmartManager.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        ValueTask<Bot> InsertBotAsync(Bot bot);
        IQueryable<Bot> SelectAllBots();
        ValueTask<Bot> SelectBotByIdAsync(Guid botId);
        ValueTask<Bot> UpdateBotAsync(Bot bot);
        ValueTask<Bot> DeleteBotAsync(Bot bot);
    }
}
