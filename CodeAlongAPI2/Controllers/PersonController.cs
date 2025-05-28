using Microsoft.AspNetCore.Mvc;

namespace CodeAlongAPI2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class PersonController : ControllerBase
    {


        [HttpGet]
        public List<Models.Person> GetPersonsABC()
        {

            return Models.Person.GetPersons();
        }

        

    }
}
