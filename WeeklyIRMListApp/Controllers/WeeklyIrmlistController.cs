using Microsoft.AspNetCore.Mvc;
using WeeklyIRMListApp.Data;
using Microsoft.EntityFrameworkCore;
using WeeklyIRMListApp.Models;
using WeeklyIRMListApp.Models.ModelDTO;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace WeeklyIRMListApp.Controllers
{
    public class WeeklyIrmlistController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<HomeController> _logger;
        public WeeklyIrmlistController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _context = context;
            _logger = logger;
        }



        /* public async Task<IActionResult> Index(DateTime? StartDateTime, DateTime? TargetEndDateTime)
         {
             // var records = _context.WeeklyIrmlists.AsQueryable();
             // var result = new List<WeeklyIrmlist>();
             var result = new List<WeeklyIrmlist>();

             if (StartDateTime.HasValue && TargetEndDateTime.HasValue)
             {
                 var startDateParam = new SqlParameter("@startDate", StartDateTime);
                 var endDateParam = new SqlParameter("@endDate", TargetEndDateTime);
                 var currentDate = new SqlParameter("@currentDate", DateTime.Now);

                 var resultRaw = await _context.WeeklyIrmlists.FromSqlRaw("EXEC spDateRangeGetIRM @startDate, @endDate, @currentDate",
                                                                        startDateParam,
                                                                        endDateParam,
                                                                        currentDate).ToListAsync();
                 result = resultRaw.Select(r => new WeeklyIrmlist
                 {
                     Key = r.Key,
                     ChangeTicket = r.ChangeTicket,
                     Summary = r.Summary,
                     IssueType = r.IssueType,
                     Applications = r.Applications,
                     Reporter = r.Reporter,
                     Status = r.Status,
                     Created = r.Created,
                     StartDateTime = r.StartDateTime,
                     TargetEndDateTime = r.TargetEndDateTime,
                     ReviewStatus = r.ReviewStatus,
                     PrerequisiteTicket = r.PrerequisiteTicket,
                     MiddlewareTask = r.MiddlewareTask,
                     BuildType = r.BuildType,
                     ElevatedPermission = r.ElevatedPermission,
                     TakeoffsOwner = r.TakeoffsOwner,
                     Remarks = r.Remarks,
                     Flag = r.Flag
                 }).ToList();
             }

             // Write debug statement here to print and show after running the app

             *//*var currentDate = DateTime.Now;
             foreach (var item in result)
             {
                 item.Flag = GetFlag(item.Created, item.StartDateTime, currentDate, item.Status.ToUpper());
             }*//*

             ViewBag.StartDateTime = StartDateTime;
             ViewBag.TargetEndDateTime = TargetEndDateTime;

             return View(result);
         }*/


        public async Task<IActionResult> Index(DateTime? StartDateTime, DateTime? TargetEndDateTime)
        {
            var result = new List<WeeklyIrmlist>();

            if (StartDateTime.HasValue && TargetEndDateTime.HasValue)
            {
                var startDateParam = new SqlParameter("@startDate", StartDateTime);
                var endDateParam = new SqlParameter("@endDate", TargetEndDateTime);
                var currentDateParam = new SqlParameter("@currentDate", DateTime.Now);

                var sql = "EXEC spDateRangeGetIRM @startDate, @endDate, @currentDate";

                // Use the DTO to get the results from the stored procedure
                var resultRaw = await _context.Set<WeeklyIrmlistDto>().FromSqlRaw(sql, startDateParam, endDateParam, currentDateParam).ToListAsync();

                // Manually map the results from the DTO to the model
                result = resultRaw.Select(r => new WeeklyIrmlist
                {
                    Key = r.Key,
                    ChangeTicket = r.ChangeTicket,
                    Summary = r.Summary,
                    IssueType = r.IssueType,
                    Applications = r.Applications,
                    Reporter = r.Reporter,
                    Status = r.Status,
                    Created = r.Created,
                    StartDateTime = r.StartDateTime,
                    TargetEndDateTime = r.TargetEndDateTime,
                    ReviewStatus = r.ReviewStatus,
                    PrerequisiteTicket = r.PrerequisiteTicket,
                    MiddlewareTask = r.MiddlewareTask,
                    BuildType = r.BuildType,
                    ElevatedPermission = r.ElevatedPermission,
                    TakeoffsOwner = r.TakeoffsOwner,
                    Remarks = r.Remarks,
                    Flag = r.Flag // Explicitly map the Flag property
                }).ToList();

                // Log the results to inspect the values
                _logger.LogDebug("Result count: {count}", result.Count);
                foreach (var item in result)
                {
                    _logger.LogDebug("Item: {@item}", item); // Log each item to inspect values
                }
            }

            ViewBag.StartDateTime = StartDateTime;
            ViewBag.TargetEndDateTime = TargetEndDateTime;

            return View(result);
        }

        /*private string GetFlag(DateTime create, DateTime start, DateTime currentDate, String status)
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
        }*/
    }
}
