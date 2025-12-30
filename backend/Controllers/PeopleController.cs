using backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PeopleController : ControllerBase
    {
        private readonly AppDbContext _context;
        public PeopleController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> AddPerson(Person person)
        {
            try
            {
                _context.People.Add(person);
                await _context.SaveChangesAsync();
                return Ok(person); // 200 ok status code with the added person
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while adding the person: " + ex.Message); // 500 internal server error with exception message
            }
            
        }

        [HttpGet]
        public IActionResult GetAllPeople()
        {
            var people = _context.People.ToList();
            return Ok(people);  
        }
    }
}