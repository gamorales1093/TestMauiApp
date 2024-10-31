using BackendTestApp.Infraestructure;
using BackendTestApp.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using BackendTestApp.Helper;

namespace BackendTestApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProspectController : ControllerBase
    {

        private readonly ILogger<ProspectController> _logger;
        private ApplicationDbContext _context { get; set; }

        public ProspectController(ILogger<ProspectController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _context = db;
        }

        [HttpGet(Name = "GetProspects")]
        public IEnumerable<Prospect> GetProspects()
        {
            return _context.Prospects.ToList();
        }

        [HttpPost(Name = "PostProspect")]
        public async Task<ActionResult<Prospect>> PostProspect(Prospect prospect)
        {
            try
            {
                _context.Prospects.Add(prospect);
                await _context.SaveChangesAsync();

                return StatusCode((int)HttpStatusCode.Created, prospect);
            }
            catch (Exception exception)
            {
                return exception.ConvertToActionResult(HttpContext);
            }
        }



    }
}