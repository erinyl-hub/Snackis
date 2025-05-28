namespace CodeAlongDI.Services
{
    public class Utilities : IUtilities
    {

        public DateTime TodayDate { get; set; }

        public int AnyRandomNumber { get; set; }

        public string Message { get; set; }

        public Utilities()
        {
            TodayDate = DateTime.Now;
            AnyRandomNumber = Random.Shared.Next(1000, 10000);
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
