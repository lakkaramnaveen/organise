using backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public async Task<IActionResult> GetAllPeople()
        {
            try
            {
                var people = await _context.People.ToListAsync();
                return Ok(people); // 200 ok status code with the list of people
                
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while retrieving people."); // 500 internal server error
            }
             
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetPersonWithID(int id)
        {
            try
            {
                // select person with specific ID
                var person = await _context.People.FindAsync(id);
                if (person == null)
                {
                    return NotFound(); // 404 not found if person does not exist
                }
                return Ok(person); // 200 ok status code with the person          
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while retrieving people."); // 500 internal server error
            }
             
        }
    }
}