namespace models
{
    public class Person
    {
        public Person() { }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public Person(string name, int age, string surname)
        {
            Name = name;
            Surname = surname;
            Age = age;
        }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public string CompleteName => $"{Name} {Surname}".ToUpper();
    }
}
