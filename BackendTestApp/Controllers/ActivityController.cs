using BackendTestApp.Helper;
using BackendTestApp.Infraestructure;
using BackendTestApp.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace BackendTestApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ActivityController : ControllerBase
    {

        private readonly ILogger<ActivityController> _logger;
        private ApplicationDbContext _context { get; set; }

        public ActivityController(ILogger<ActivityController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _context = db;
        }


        [HttpGet("{IdProspect}")]
        public async Task<ActionResult<IEnumerable<Activity>>> GetActivitiesById(int IdProspect)
        {
            try
            {
                var activities =  this._context.Activities.Where(x=>x.ProspectId == IdProspect).Include(x=>x.Type);
                return Ok(activities);
            }
            catch (Exception exception)
            {
                return exception.ConvertToActionResult(HttpContext);
            }
        }

        [HttpPost(Name = "PostActivity")]
        public async Task<ActionResult<Activity>> PostActivity(Activity activity)
        {
            try
            {
                activity.Type = null;
                _context.Activities.Add(activity);
                await _context.SaveChangesAsync();

                return StatusCode((int)HttpStatusCode.Created, activity);
            }
            catch (Exception exception)
            {
                return exception.ConvertToActionResult(HttpContext);
            }
        }

        [HttpPut("{IdActivity}")]
        public async Task<IActionResult> PutActivity(int IdActivity, Activity activity)
        {
            if (IdActivity != activity.Id)
            {
                return BadRequest();
            }

            _context.Entry(activity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return Ok("Record successfully updated");
            }
            catch (Exception exception)
            {
                return exception.ConvertToActionResult(HttpContext);
            }
        }

        [HttpDelete("{IdActivity}")]
        public async Task<IActionResult> DeleteActivityById(int IdActivity)
        {
            try
            {
                if (IdActivity <= 0)
                    return BadRequest("Invalid ID");

                var activity = this._context.Activities.FirstOrDefault(x => x.Id == IdActivity);

                if (activity == null)
                    return NotFound();

                _context.Activities.Remove(activity);
               await  _context.SaveChangesAsync();
                return Ok("Record successfully deleted");
            }
            catch (Exception exception)
            {
                return exception.ConvertToActionResult(HttpContext);
            }
        }



    }
}
