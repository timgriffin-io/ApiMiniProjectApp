using ApiMiniProject.Models;
using Microsoft.AspNetCore.Mvc;


namespace ApiMiniProject.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PersonController : ControllerBase
{
    private readonly ILogger<PersonController> _logger;
    private static List<PersonModel> _persons = new();
    public PersonController(ILogger<PersonController> logger)
    {
        _logger = logger;
    }

    [HttpGet("GetPeople")]
    public IActionResult GetPeople()
    {
        return Ok(_persons);
    }

    [HttpGet("GetPerson/{id}")]
    public IActionResult GetPerson(int id)
    {
        return Ok(_persons.Where(x => x.Id == id));
    }


    [HttpPost]
    public IActionResult Post([FromBody] PersonModel person)
    {
        if (BusinessLogic.PersonIsValid(person, _persons))
        {
            _persons.Add(person);
            _logger.LogInformation($"{person.Id} : {person.FirstName} {person.LastName} was added to persons list");
            return Ok();
        }

        _logger.LogInformation("Invalid Person Object");
        return BadRequest();

    }
}
