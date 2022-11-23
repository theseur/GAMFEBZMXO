using GAMF.Data;
using GAMF.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using System.Security.Policy;

namespace GAMF.Controllers
{
    public class KreditController : Controller
    {

        private readonly GAMFDbContext _context;

        public KreditController(GAMFDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IActionResult KreditDateReport()
        {
            var q = (from pd in _context.Students
                     join od in _context.Enrollments on pd.Id equals od.StudentId
                     join _ts in _context.Courses on od.CourseId equals _ts.CourseId
                     group new { pd, od, _ts } by new { pd.LastName } into newGroup
                    // orderby newGroup.Key
                     select new KreditDateVM
                     {
                       LastName=newGroup.First().pd.LastName,
                        FirstMidName =newGroup.First().pd.FirstMidName,
                         Gradesint = newGroup.Sum(c=>c._ts.Credits)
                     }).ToList();                                   
            return View(q);
        }
      
       public static int Kreditszam( string? _crednum)
        {
          
            if (_crednum == null)
            {
                return 0;
            }
            else
            {
                switch (_crednum.ToUpper())
                {
                    case "A":
                        return 4;
                        break;
                    case "B":
                        return 4;
                    case "C":
                        return 4;
                    case "D":
                        return 4;
                        break;
                    default:
                        return 0;
                        break;
                }
            }
        }
       
    }
}
