namespace CodeAlongDI.Services
{
    public interface IUtilities
    {
        public DateTime TodayDate { get; set; }

        public int AnyRandomNumber { get; set; }

        public string Message { get; set; }


        DateTime GetDate();

        int GetRandomInt();
    }
}
