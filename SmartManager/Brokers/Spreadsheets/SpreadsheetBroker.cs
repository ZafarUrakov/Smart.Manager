//===========================
// Copyright (c) Tarteeb LLC
// Managre quickly and easy
//===========================

using System.Collections.Generic;
using System.IO;
using System;
using SmartManager.Models.ExternalStudents;
using Bytescout.Spreadsheet;
using SmartManager.Models.Students;

namespace SmartManager.Brokers.Spreadsheets
{
    public class SpreadsheetBroker : ISpreadsheetBroker
    {
        public List<ExternalStudent> ImportStudents(MemoryStream stream)
        {
            var importStudents = new List<ExternalStudent>();

            Spreadsheet document = new Spreadsheet();

            document.LoadFromStream(stream);

            Worksheet worksheet = document.Workbook.Worksheets[0];

            for (int row = 1; row <= worksheet.UsedRangeRowMax; row++)
            {
                var externalStudent = new ExternalStudent();

                externalStudent.Id = Guid.NewGuid();
                externalStudent.GivenName = worksheet.Cell(row, 0).ToString();
                externalStudent.Surname = worksheet.Cell(row, 1).ToString();
                externalStudent.PhoneNumber = worksheet.Cell(row, 2).ToString();
                string dateString = worksheet.Cell(row, 5).ToString();
                if (DateTimeOffset.TryParse(dateString, out DateTimeOffset date))
                {
                    externalStudent.BirthDate = date;
                }
                string genderString = worksheet.Cell(row, 4).ToString();
                externalStudent.Gender = ConvertToGender(genderString);
                externalStudent.Group.GroupName = worksheet.Cell(row, 3).ToString();
                externalStudent.Group.Id =  Guid.NewGuid();
                externalStudent.GroupId = externalStudent.Group.Id;

                importStudents.Add(externalStudent);
            }

            return importStudents;
        }

        private Gender ConvertToGender(string genderString)
        {
            if (Enum.TryParse<Gender>(genderString, out Gender gender))
            {
                return gender;
            }
            else
            {
                return Gender.Unknown;
            }
        }
    }
}
