
namespace CodeAlongDI.Services
{
    public class UtilitiesMock : IUtilities
    {
        public DateTime TodayDate { get; set; }
        public int AnyRandomNumber { get ; set; }
        public string Message { get; set; }

        public UtilitiesMock()
        {
            TodayDate = DateTime.Parse("2025-01-01 12:00");
            AnyRandomNumber = 1234;
        }


        public DateTime GetDate()
        {
            return TodayDate;
        }

        public int GetRandomInt()
        {
            return AnyRandomNumber;
        }
    }
}
