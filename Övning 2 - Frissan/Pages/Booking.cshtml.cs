using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Övning_2___Frissan.Models;

namespace Övning_2___Frissan.Pages
{
    public class BookingModel : PageModel
    {
        public Models.Hairdressers hairdressers = Models.Hairdressers.GetHairdressersInstance();
        public Models.Bookings bookings = Models.Bookings.GetBookingsInstance();

        [BindProperty]
        public DateTime ChosenDate { get; set; }

        public List<Models.Hairdresser> hairdressersList { get; set; }

        public Dictionary<string,Dictionary<DateTime, Models.Booking>> bookingList { get; set; }

        [BindProperty]
        public string ChosenHairdresser { get; set; }

        
        public Dictionary<DateTime, Models.Booking> HairdresserSchedule = new Dictionary<DateTime, Booking>();

        public TimeOnly timeToCheck { get; set; } = new TimeOnly(9, 0);




        public void OnGet()
        {
            hairdressersList = hairdressers.hairdressers;
            bookingList = bookings.bookings;
        }

        public void OnPost()
        {
            HairdresserSchedule = bookingList[ChosenHairdresser];

        }
    }
}
