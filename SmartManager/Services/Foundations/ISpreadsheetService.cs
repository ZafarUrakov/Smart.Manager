//===========================
// Copyright (c) Tarteeb LLC
// Managre quickly and easy
//===========================

using SmartManager.Models.ExternalStudents;
using System.Collections.Generic;
using System.IO;

namespace SmartManager.Services.Foundations
{
    public interface ISpreadsheetService
    {
        List<ExternalStudent> GetExternalApplicants(MemoryStream stream);
    }
}
