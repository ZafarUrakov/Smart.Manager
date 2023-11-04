using Microsoft.AspNetCore.Mvc;
using SmartManager.Models.Groups;
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

        public IActionResult GetStudentsWithGroup(Guid groupId)
        {
            IQueryable<Student> applicants =
                this.studentProcessingService.RetrieveAllStudents().Where(a => a.Group.Id == groupId);

            return View(applicants);
        }

        public IActionResult GetStudentsWithAttendances()
        {
            IQueryable<Student> students = this.studentProcessingService.RetrieveAllStudents();

            return View(students);
        }


        public IActionResult GetStudentsWithPayments(Guid groupId)
        {
            IQueryable<Student> students = 
                this.studentProcessingService.RetrieveAllStudents().Where(s => s.Group.Id == groupId);

            var group = new Group();

            foreach(var student in students)
            {
                student.Group = group;
            }

            return View(students);
        }
        public async ValueTask<ActionResult> GetStudentAsync(Guid Id)
        {
            var student = 
                await this.studentProcessingService.RetrieveStudentByIdAsync(Id);

            return Ok(student);
        }

        [HttpGet]
        public IActionResult DeleteStudentAsync(Guid studentId)
        {
            IQueryable<Student> students = this.studentProcessingService.RetrieveAllStudents();

            Student student = students.SingleOrDefault(a => a.Id == studentId);

            this.studentProcessingService.RemoveStudentAsync(student.Id);

            return RedirectToAction("GetStudents");
        }

        [HttpGet]
        public IActionResult DeleteStudentInGroup(Guid studentId)
        {
            IQueryable<Student> students = this.studentProcessingService.RetrieveAllStudents();

            Student student = students.SingleOrDefault(a => a.Id == studentId);

            this.studentProcessingService.RemoveStudentAsync(student.Id);

            return RedirectToAction("ShowStudentWithGroup");
        }
    }
}
