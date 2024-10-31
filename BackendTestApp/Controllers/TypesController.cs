using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BackendTestApp.Infraestructure;
using BackendTestApp.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace BackendTestApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TypesController : ControllerBase
    {
        public ApplicationDbContext _context { get; set; }
        private readonly ILogger<TypesController> _logger;

        public TypesController(ILogger<TypesController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _context = db;
        }

        [HttpGet(Name = "GetTypes")]
        public IEnumerable<Types> GetTypes()
        {
            return _context.Types;
        }
    }
}

