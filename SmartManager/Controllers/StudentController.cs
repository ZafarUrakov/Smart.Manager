using Microsoft.AspNetCore.Mvc;
using SmartManager.Models.Students;
using SmartManager.Services.Processings.Students;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SmartManager.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentProcessingService studentProcessingService;

        public StudentController(IStudentProcessingService studentProcessingService)
        {
            this.studentProcessingService = studentProcessingService;
        }

        public IActionResult GetStudents()
        {
            IQueryable<Student> students = this.studentProcessingService.RetrieveAllStudents();

            return View(students);
        }

        public async ValueTask<ActionResult> GetStudentAsync(Guid studentId)
        {
            var student = 
                await this.studentProcessingService.RetrieveStudentByIdAsync(studentId);

            return Ok(student);
        }

        public IActionResult GetStudentsWithPaymentAsync(Guid groupId)
        {
            IQueryable<Student> students = this.studentProcessingService.RetrieveAllStudents().Where(s => s.Group.Id == groupId);

            return View(students);
        }
    }
}
