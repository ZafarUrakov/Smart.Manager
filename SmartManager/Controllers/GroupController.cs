//===========================
// Copyright (c) Tarteeb LLC
// Managre quickly and easy
//===========================

using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SmartManager.Models.Groups;
using SmartManager.Services.Processings.Groups;

namespace SmartManager.Controllers
{
    public class GroupController : Controller
    {
        private readonly IGroupProcessingService groupProcessingService;

        public GroupController(IGroupProcessingService groupProcessingService)
        {
            this.groupProcessingService = groupProcessingService;
        }

        public ActionResult GetAllGroups()
        {
            IQueryable<Group> groups = this.groupProcessingService.RetrieveAllGroups();

            return View(groups);
        }
    }
}
