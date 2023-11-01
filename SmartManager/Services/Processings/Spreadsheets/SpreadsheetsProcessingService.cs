//===========================
// Copyright (c) Tarteeb LLC
// Managre quickly and easy
//===========================

using SmartManager.Brokers.Loggings;
using SmartManager.Models.ExternalStudents;
using SmartManager.Models.Groups;
using SmartManager.Models.Students;
using SmartManager.Services.Foundations.Spreadsheets;
using SmartManager.Services.Processings.Groups;
using SmartManager.Services.Processings.Students;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace SmartManager.Services.Processings.Spreadsheets
{
    public class SpreadsheetsProcessingService
    {
        private readonly ISpreadsheetService spreadsheetService;
        private readonly IStudentProcessingService applicantProcessingService;
        private readonly IGroupProcessingService groupProcessingService;
        private readonly ILoggingBroker loggingBroker;

        public SpreadsheetsProcessingService(
            IStudentProcessingService applicantProcessingService,
            IGroupProcessingService groupProcessingService,
            ILoggingBroker loggingBroker,
            ISpreadsheetService spreadsheetService)
        {
            this.applicantProcessingService = applicantProcessingService;
            this.groupProcessingService = groupProcessingService;
            this.loggingBroker = loggingBroker;
            this.spreadsheetService = spreadsheetService;
        }

        public async Task ProcessImportRequest(MemoryStream stream)
        {
            List<ExternalStudent> validExternalStudents =
                this.spreadsheetService.GetExternalStudents(stream);


            foreach (var externalStudent in validExternalStudents)
            {

                Group ensureGroup =
                    await groupProcessingService
                    .EnsureGroupExistsByName(externalStudent.Group.GroupName);

                Student applicant = MapToStudent(externalStudent, ensureGroup);

                await applicantProcessingService.AddStudentAsync(applicant);
            }
        }
        private Student MapToStudent(ExternalStudent externalStudent, Group ensureGroup)
        {
            return new Student
            {
                Id = Guid.NewGuid(),
                GivenName = externalStudent.GivenName,
                Surname = externalStudent.Surname,
                Gender = externalStudent.Gender,
                PhoneNumber = externalStudent.PhoneNumber,
                Group = ensureGroup,
            };
        }
    }
}
