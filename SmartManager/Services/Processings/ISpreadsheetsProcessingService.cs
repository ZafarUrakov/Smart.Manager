//===========================
// Copyright (c) Tarteeb LLC
// Managre quickly and easy
//===========================

using SmartManager.Models.ExternalStudents;
using System.Collections.Generic;
using System.IO;

namespace SmartManager.Services.Processings
{
    public interface ISpreadsheetsProcessingService
    {
        List<ExternalStudent> ReadExternalApplicants(MemoryStream stream);
    }
}
