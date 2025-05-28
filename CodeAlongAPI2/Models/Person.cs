namespace CodeAlongAPI2.Models
{
    public class Person
    {
        public string Name { get; set; }
        public int BirthYear { get; set; }

        public static List<Person> GetPersons()
        {
            List<Person> persons = new List<Person>();
            persons.Add(new Person { Name = "Lisa", BirthYear = 1995 });
            persons.Add(new Person { Name = "Anders", BirthYear = 1988 });
            return persons;

        }

    }
}
