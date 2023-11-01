//===========================
// Copyright (c) Tarteeb LLC
// Managre quickly and easy
//===========================

using SmartManager.Models.ExternalStudents;
using SmartManager.Services.Foundations;
using System.Collections.Generic;
using System.IO;

namespace SmartManager.Services.Processings
{
    public class SpreadsheetsProcessingService
    {
        private readonly ISpreadsheetService spreadsheetService;

        public SpreadsheetsProcessingService(ISpreadsheetService spreadsheetService)
        {
            this.spreadsheetService = spreadsheetService;
        }

        public List<ExternalStudent> ReadExternalStudents(MemoryStream stream)
        {
            List<ExternalStudent> validExternalStudents =
                spreadsheetService.GetExternalStudents(stream);

            return validExternalStudents;
        }
    }
}
