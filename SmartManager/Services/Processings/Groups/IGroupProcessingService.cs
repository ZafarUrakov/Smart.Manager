//===========================
// Copyright (c) Tarteeb LLC
// Managre quickly and easy
//===========================

using System.Linq;
using System.Threading.Tasks;
using System;
using System.Text.RegularExpressions;

namespace SmartManager.Services.Processings.Groups
{
    public interface IGroupProcessingService
    {
        ValueTask<Group> EnsureGroupExistsByName(string groupName);
        ValueTask<Group> AddGroupAsync(Group group);
        ValueTask<Group> RetrieveGroupByIdAsync(Guid groupid);
        IQueryable<Group> RetrieveAllGroups();
        ValueTask<Group> ModifyGroupAsync(Group group);
        ValueTask<Group> RemoveGroupAsync(Guid groupid);
    }
}
