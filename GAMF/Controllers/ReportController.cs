using GAMF.Data;
using GAMF.Models;
using Microsoft.AspNetCore.Mvc;

namespace GAMF.Controllers
{
    public class ReportController : Controller
    {
        private readonly GAMFDbContext _context;

        public ReportController(GAMFDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IActionResult EnrollmentDateReport()
        {
            //// 1. megoldás
            //var result = from student in _context.Students
            //             group student by student.EnrollmentDate into dateGroup
            //             select new EnrollmentDateVM
            //             {
            //                 EnrollmentDate = dateGroup.Key,
            //                 StudentCount = dateGroup.Count()
            //             };

            // 2. megoldás
            var result = _context.Students.GroupBy(s => s.EnrollmentDate)
                .Select(s => new EnrollmentDateVM
                {
                    EnrollmentDate = s.Key,
                    StudentCount = s.Count()
                });


            return View(result.ToList());
        }

    }
}
