//===========================
// Copyright (c) Tarteeb LLC
// Managre quickly and easy
//===========================

using System.Linq;
using System.Threading.Tasks;
using System;
using SmartManager.Models.Groups;

namespace SmartManager.Services.Foundations.Groups
{
    public interface IGroupService
    {
        ValueTask<Group> AddGroupAsync(Group group);
        ValueTask<Group> RetrieveGroupByIdAsync(Guid groupid);
        IQueryable<Group> RetrieveAllGroups();
        ValueTask<Group> ModifyGroupAsync(Group group);
        ValueTask<Group> RemoveGroupAsync(Guid groupid);
    }
}
