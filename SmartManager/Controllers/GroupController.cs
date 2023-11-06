//===========================
// Copyright (c) Tarteeb LLC
// Managre quickly and easy
//===========================

using Microsoft.AspNetCore.Mvc;
using SmartManager.Models.Groups;
using SmartManager.Services.Processings.Groups;
using SmartManager.Services.Processings.Students;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SmartManager.Controllers
{
    public class GroupController : Controller
    {
        private readonly IGroupProcessingService groupProcessingService;
        private readonly IStudentProcessingService studentProcessingService;

        public GroupController(IGroupProcessingService groupProcessingService, IStudentProcessingService studentProcessingService)
        {
            this.groupProcessingService = groupProcessingService;
            this.studentProcessingService = studentProcessingService;
        }
        public IActionResult GetGroups()
        {
            IQueryable<Group> groups = this.groupProcessingService.RetrieveAllGroups();

            return View(groups);
        }

        public IActionResult GetGroupsForAttendances()
        {
            IQueryable<Group> groups = this.groupProcessingService.RetrieveAllGroups();

            return View(groups);
        }

        public IActionResult GetGroupsForPayments()
        {
            IQueryable<Group> groups = this.groupProcessingService.RetrieveAllGroups();

            return View(groups);
        }

        [HttpGet]
        public async ValueTask<IActionResult> DeleteGroup(Guid groupId)
        {
            IQueryable<Group> groups = this.groupProcessingService.RetrieveAllGroups();

            Group group = groups.SingleOrDefault(a => a.Id == groupId);

            await this.groupProcessingService.RemoveGroupAsync(group.Id);

            return RedirectToAction("GetGroups");
        }
    }
}
