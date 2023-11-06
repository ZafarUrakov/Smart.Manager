using Microsoft.AspNetCore.Mvc;
using SmartManager.Models.Students;
using SmartManager.Services.Processings.Groups;
using SmartManager.Services.Processings.Payments;
using SmartManager.Services.Processings.PaymentStatistics;
using SmartManager.Services.Processings.Students;
using SmartManager.Services.Processings.StudentsStatistics;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SmartManager.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentProcessingService studentProcessingService;
        private readonly IPaymentStatisticsProccessingService paymentStatisticsProccessingService;
        private readonly IGroupProcessingService groupProcessingService;
        private readonly IPaymentProcessingService paymentProcessingService;
        private readonly IStudentsStatisticProccessingService groupStatisticProccessingService;

        public StudentController(
            IStudentProcessingService studentProcessingService,
            IPaymentStatisticsProccessingService paymentStatisticsProccessingService,
            IGroupProcessingService groupProcessingService,
            IPaymentProcessingService paymentProcessingService,
            IStudentsStatisticProccessingService groupStatisticProccessingService)
        {
            this.studentProcessingService = studentProcessingService;
            this.paymentStatisticsProccessingService = paymentStatisticsProccessingService;
            this.groupProcessingService = groupProcessingService;
            this.paymentProcessingService = paymentProcessingService;
            this.groupStatisticProccessingService = groupStatisticProccessingService;
        }

        public IActionResult PostStudent()
        {
            return View();
        }

        // post
        [HttpPost]
        public async ValueTask<IActionResult> PostStudent(Student student)
        {
            await this.studentProcessingService.AddStudentAsync(student);

            await this.groupStatisticProccessingService
                 .UpdateStatisticsByStudentAsync(student);

            await this.paymentStatisticsProccessingService.AddPaymentStatisticAsync(student);

            return RedirectToAction("GetStudents");
        }

        public IActionResult GetStudents()
        {
            IQueryable<Student> students = this.studentProcessingService.RetrieveAllStudents();

            return View(students);
        }

        public IActionResult GetStudentsWithGroup(Guid groupId)
        {
            IQueryable<Student> applicants =
                this.studentProcessingService.RetrieveAllStudents().Where(a => a.GroupId == groupId);

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
                this.studentProcessingService.RetrieveAllStudents().Where(s => s.GroupId == groupId);

            return View(students);
        }

        public async ValueTask<ActionResult> GetStudentAsync(Guid Id)
        {
            var student =
                await this.studentProcessingService.RetrieveStudentByIdAsync(Id);

            return Ok(student);
        }

        [HttpGet]
        public async ValueTask<IActionResult> DeleteStudent(Guid studentId)
        {
            IQueryable<Student> students = this.studentProcessingService.RetrieveAllStudents();

            Student student = students.SingleOrDefault(a => a.Id == studentId);

            await this.studentProcessingService.RemoveStudentAsync(student.Id);

            return RedirectToAction("GetStudents");
        }

        [HttpGet]
        public async ValueTask<IActionResult> DeleteStudentInGroup(Guid studentId)
        {
            IQueryable<Student> students = this.studentProcessingService.RetrieveAllStudents();

            Student student = students.SingleOrDefault(a => a.Id == studentId);

            await this.studentProcessingService.RemoveStudentAsync(student.Id);

            return RedirectToAction("GetStudentsWithGroup");
        }
    }
}
