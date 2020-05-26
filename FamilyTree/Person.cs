using System;

namespace FamilyTree
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Status { get; set; }

        public Person Father { get; set; }

        public Person Mother { get; set; }

        public string GetDescription()
            {
                var startTxt = "";
                if (FirstName != null) startTxt += FirstName + " ";
                if (LastName != null) startTxt += LastName + " ";
                startTxt += $"(Id:{Id})";

                return startTxt;
            }
        public void ShowPerson()
        {
            Console.WriteLine(GetDescription());
        }
    }
}