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
    public class SpreadsheetsProcessingService : ISpreadsheetsProcessingService
    {
        private readonly ISpreadsheetService spreadsheetService;
        private readonly IStudentProcessingService studentProcessingService;
        private readonly IGroupProcessingService groupProcessingService;
        private readonly ILoggingBroker loggingBroker;

        public SpreadsheetsProcessingService(
            IStudentProcessingService studentProcessingService,
            IGroupProcessingService groupProcessingService,
            ILoggingBroker loggingBroker,
            ISpreadsheetService spreadsheetService)
        {
            this.studentProcessingService = studentProcessingService;
            this.groupProcessingService = groupProcessingService;
            this.loggingBroker = loggingBroker;
            this.spreadsheetService = spreadsheetService;
        }

        public async ValueTask<List<Student>> ProcessImportRequest(MemoryStream stream)
        {
            List<Student> mappedStudents = new List<Student>();

            List<ExternalStudent> validExternalStudents =
                this.spreadsheetService.GetExternalStudents(stream);

            foreach (var externalStudent in validExternalStudents)
            {

                Group ensureGroup =
                    await groupProcessingService
                    .EnsureGroupExistsByName(externalStudent.GroupName);

                Student student = MapToStudent(externalStudent, ensureGroup);

                mappedStudents.Add(student);

                await studentProcessingService.AddStudentAsync(student);
            }
            return mappedStudents;
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
                GroupId = ensureGroup.Id,
                GroupName = ensureGroup.GroupName,
            };
        }
    }
}