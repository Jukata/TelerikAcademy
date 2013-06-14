namespace RefactorHumanClass
{
    public class RefactorHumanClass
    {
        public enum Sex
        {
            Male, Female
        }

        public void CreateHuman(int age)
        {
            Human human = new Human();
            human.Age = age;

            if (age % 2 == 0)
            {
                human.Name = "Ivan";
                human.Sex = Sex.Male;
            }
            else
            {
                human.Name = "Gergana";
                human.Sex = Sex.Female;
            }
        }

        private class Human
        {
            public Sex Sex
            {
                get;
                set;
            }

            public string Name
            {
                get;
                set;
            }

            public int Age
            {
                get;
                set;
            }
        }
    }
}
