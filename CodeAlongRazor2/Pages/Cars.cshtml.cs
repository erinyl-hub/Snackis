using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CodeAlongRazor2.Pages
{
    public class CarsModel : PageModel
    {
        public List<Models.Car> Cars { get; set; } = new List<Models.Car>();
        public Models.Car? SelectedCar { get; set; }

        public void OnGet(int carId, string name)
        {
            Cars = Models.Car.MakeCars();

            if(carId != 0)
            {
                Models.Car? selectedCar = Cars.Where(c => c.Id == carId).FirstOrDefault();
                if(selectedCar != null)
                {
                    selectedCar.Make += name;  // funkar
                    SelectedCar = selectedCar;
                }
            }
        }
    }
}
