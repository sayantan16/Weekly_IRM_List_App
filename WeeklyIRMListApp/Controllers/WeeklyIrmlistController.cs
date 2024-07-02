using Microsoft.AspNetCore.Mvc;
using WeeklyIRMListApp.Data;
using Microsoft.EntityFrameworkCore;
using WeeklyIRMListApp.Models;
using System.Threading.Tasks;

namespace WeeklyIRMListApp.Controllers
{
    public class WeeklyIrmlistController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WeeklyIrmlistController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(DateTime? StartDateTime, DateTime? TargetEndDateTime)
        {
            var records = _context.WeeklyIrmlists.AsQueryable();
            var result = new List<WeeklyIrmlist>();

            if (StartDateTime.HasValue && TargetEndDateTime.HasValue)
            {
                records = records.Where(r => r.StartDateTime >= StartDateTime && r.TargetEndDateTime <= TargetEndDateTime);
                result = await records.OrderBy(r => r.StartDateTime).ToListAsync();
            }

            var currentDate = DateTime.Now;
            foreach (var item in result)
            {
                item.Flag = GetFlag(item.Created, item.StartDateTime, currentDate, item.Status.ToUpper());
            }

            ViewBag.StartDateTime = StartDateTime;
            ViewBag.TargetEndDateTime = TargetEndDateTime;

            return View(result);
        }
        private string GetFlag(DateTime create, DateTime start, DateTime currentDate, String status)
        {
            TimeSpan difference1 = start - create;
            bool within24Hrs = Math.Abs(difference1.TotalHours) <= 24;
            
            TimeSpan difference2 = start - currentDate;
            bool within48Hours = Math.Abs(difference2.TotalHours) <= 48;

            
            if (within24Hrs)
            {
                return "Started within 24 Hours of Creation";
            }
            else if (within48Hours && (status == "RELEASE REQUEST OPENED" || status == "IN TAKEOFFS APPROVAL"))
            {
                return "Difference between start date and today's date is less than 48 hours for RRO or ITO status";
            }
            else
            {
                return "NA";
            }
        }
    }
}
