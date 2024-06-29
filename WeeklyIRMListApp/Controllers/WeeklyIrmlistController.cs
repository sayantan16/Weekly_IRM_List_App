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

            ViewBag.StartDateTime = StartDateTime;
            ViewBag.TargetEndDateTime = TargetEndDateTime;

            return View(result);
        }
    }
}
