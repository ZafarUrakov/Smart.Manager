//===========================
// Copyright (c) Tarteeb LLC
// Managre quickly and easy
//===========================

using System.Linq;
using System.Threading.Tasks;
using System;
using SmartManager.Models.Students;

namespace SmartManager.Services.Processings.Students
{
    public interface IStudentProcessingService
    {
        ValueTask<Student> AddStudentAsync(Student student);
        ValueTask<Student> RetrieveStudentByIdAsync(Guid studentid);
        IQueryable<Student> RetrieveAllStudents();
        ValueTask<Student> ModifyStudentAsync(Student student);
        ValueTask<Student> ModifyStudentWithGroupAsync(Student student);
        ValueTask<Student> RemoveStudentAsync(Guid studentid);
    }
}
