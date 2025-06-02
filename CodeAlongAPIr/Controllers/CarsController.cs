using CodeAlongAPIr.Data;
using Microsoft.AspNetCore.Mvc;

namespace CodeAlongAPIr.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class CarsController : ControllerBase
    {
        private readonly CarManager _carManager;

        public CarsController(CarManager carManager) {
            _carManager = carManager;
        }

        [HttpGet]
        public async Task<List<Models.Car>> GetCars()
        {
            var cars = await _carManager.GetCars();
            return cars;
        }


        [HttpPost]
        public async Task PostCar([FromBody] Models.Car car)
        {
            await _carManager.AddCar(car);
        }

    }



}
