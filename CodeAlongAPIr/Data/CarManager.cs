using Microsoft.EntityFrameworkCore;

namespace CodeAlongAPIr.Data
{
    public class CarManager
    {
        private readonly Models.MyDbContext _context;

        public CarManager(Models.MyDbContext context)
        {
            _context = context;
        }

        public async Task AddCar(Models.Car car)
        {
            await _context.Cars.AddAsync(car);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Models.Car>> GetCars()
        {
            List<Models.Car> cars = await _context.Cars.ToListAsync();
            return cars;
        }



    }
}
