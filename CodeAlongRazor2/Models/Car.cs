namespace CodeAlongRazor2.Models
{
    public class Car
    {
        public Car(string make, int year, bool working, int id)
        {
            Id = id;
            Make = make;
            Year = year;
            Working = working;
        }

        public int Id { get; set; }
        public string Make { get; set; }
        public int Year { get; set; }
        public bool Working { get; set; }
   

    public static List<Car> MakeCars() 
        {
            var cars = new List<Car>();
            cars.Add(new Car("Saab", 2013, true, 1));
            cars.Add(new Car("Bugatti", 2003, false, 2));
            cars.Add(new Car("BMW", 2021, true, 3));

            return cars;
        }

    }
}
