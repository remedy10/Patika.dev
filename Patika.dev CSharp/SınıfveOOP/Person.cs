namespace SınıfveOOP
{
    class Person
    {
        private int age;
        public Person()
        {

        }
        public Person(int initalAge)
        {
            if (initalAge < 0)
            {
                age = 0;
                Console.WriteLine("Age is not valid, setting age to 0.");

            }
            else
                age = initalAge;
        }
        public int Age
        {
            get
            {

                return age;

            }
            set
            {
                if (value > 0)
                {
                    this.age += value;
                }
                else
                {
                    Console.WriteLine("Age is not valid, setting age to 0.");
                    this.age = 0;
                }


            }

        }
        public void yearPasses()
        {
            age += 1;
        }
        public void amIOld()
        {

            if (age < 13)
            {
                Console.WriteLine("You are young.");
            }
            else if (age >= 13 && age < 18)
            {
                Console.WriteLine("You are a teenager.");
            }
            else
                Console.WriteLine("You are old.");
        }
    }
}