namespace CodeAlongDI.Services
{
    public class UtilitiesToBeTransient
    {
        public DateTime TodayDate { get; set; }

        public int AnyRandomNumber { get; set; }

        public string Message { get; set; }

        public UtilitiesToBeTransient()
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
