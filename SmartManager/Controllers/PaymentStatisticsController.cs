//===========================
// Copyright (c) Tarteeb LLC
// Managre quickly and easy
//===========================

using Microsoft.AspNetCore.Mvc;

namespace SmartManager.Controllers
{
    public class PaymentStatisticsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
