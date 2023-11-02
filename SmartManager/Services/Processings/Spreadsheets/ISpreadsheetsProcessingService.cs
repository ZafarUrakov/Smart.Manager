//===========================
// Copyright (c) Tarteeb LLC
// Managre quickly and easy
//===========================

using SmartManager.Models.ExternalStudents;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace SmartManager.Services.Processings.Spreadsheets
{
    public interface ISpreadsheetsProcessingService
    {
        Task ProcessImportRequest(MemoryStream stream);
    }
}
