using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Övning_2___Frissan.Models
{
    public class Hairdresser
    {


        [Required]
        [JsonPropertyName("name")]
        [Display (Name = "Hairdresser name:")]
        public string Name { get; set; }

        [Required]
        [JsonPropertyName("cutting")]
        [Display(Name = "Cutting price:")]
        public int Cutting { get; set; }

        [Required]
        [JsonPropertyName("coloring")]
        [Display(Name = "Coloring price:")]
        public int Coloring { get; set; }

        [Required]
        [JsonPropertyName("extensions")]
        [Display(Name = "Extension price:")]
        public int Extensions { get; set; }


        public Dictionary<string,Booking> Schedule { get; set; }



    }

    public class Hairdressers
    {
        private static readonly Hairdressers _hairdressers = new Hairdressers();
        public List<Hairdresser> hairdressers = new List<Hairdresser>();

        private Hairdressers () { }

        public static Hairdressers GetHairdressersInstance() => _hairdressers;

    }


    public class Booking
    {
        public DateTime Appointment { get; set; }
        public string Customer { get; set; }
    }


    public class Bookings
    {
        private static readonly Bookings _bookings = new Bookings();
        public Dictionary<string, Dictionary<DateTime, Booking>> bookings = new Dictionary<string, Dictionary<DateTime, Booking>>();

        private Bookings(){}

        public static Bookings GetBookingsInstance() => _bookings;
    }
}
