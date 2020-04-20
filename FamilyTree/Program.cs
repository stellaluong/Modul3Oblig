using System;
using System.Collections.Generic;

namespace FamilyTree
{
    class Program
    {
        private static List<Person> showFamily = SimpsonsFamily();

        public static void Main(string[] args)
        {
            Console.WriteLine("Type 'help' to start.");
            while (true)
            {
                var input = Console.ReadLine();
                Console.WriteLine();

                input = input.ToLower();

                if (input == "help")
                {
                    ShowHelp();
                }
                else if (input == "list")
                {
                    foreach (var person in showFamily)
                    {
                        person.ShowPerson();
                        Console.WriteLine();
                    }
                }

                else if (input.Length > 3 && input.Substring(0, 3) == "id ")
                {
                    var getIdNo = input.Substring(3);
                    var parseIdNo = int.Parse(getIdNo);
                    var idNo = showFamily.FindIndex(x => x.Id == parseIdNo);

                    var personId = showFamily[idNo];
                    personId.ShowPerson();
                    ShowChildren(personId);
                }
                else
                {
                    Console.WriteLine("ID not found, or invalid ID. Try again or write \"help\".");
                }
            }
        }

        private static void ShowChildren(Object parentId)
        {
            foreach (var child in showFamily)
            {
                if (child.Father == parentId || child.Mother == parentId)
                {
                    Console.WriteLine($"Child: {child.FirstName} - Id: {child.Id}, ");
                }
            }
        }

        private static void ShowHelp()
        {
            Console.WriteLine("Type 'help' to show list of commandos.");
            Console.WriteLine("Type 'list' to see a list of all the people.");
            Console.WriteLine("Type 'id' + a number to show a persons information.");
        }

        public static List<Person> SimpsonsFamily()
        {
            var abrahamSimpson = new Person { Id = 1, FirstName = "Abraham", LastName = "Simpsons", Status = "Alive" };
            var monaOlsen = new Person { Id = 2, FirstName = "Mona", LastName = "Olsen", Status = "Deceased" };
            var homerSimpson = new Person { Id = 3, FirstName = "Homer", LastName = "Simpson", Status = "Alive" };
            var marjorieSimpson = new Person { Id = 4, FirstName = "Marjorie", LastName = "Simpson", Status = "Alive" };
            var barthSimpson = new Person { Id = 5, FirstName = "Barth", LastName = "Simpson", Status = "Alive" };
            var lisaSimpson = new Person { Id = 6, FirstName = "Lisa", LastName = "Simpson", Status = "Alive" };
            var margaretSimpson = new Person { Id = 7, FirstName = "Margaret", LastName = "Simpson", Status = "Alive" };

            barthSimpson.Father = homerSimpson;
            lisaSimpson.Father = homerSimpson;
            margaretSimpson.Father = homerSimpson;
            barthSimpson.Mother = marjorieSimpson;
            lisaSimpson.Mother = marjorieSimpson;
            margaretSimpson.Mother = marjorieSimpson;
            homerSimpson.Father = abrahamSimpson;
            homerSimpson.Mother = monaOlsen;

            var listSimpsons = new List<Person>
            {
                abrahamSimpson,
                monaOlsen, 
                homerSimpson, 
                marjorieSimpson, 
                barthSimpson, 
                lisaSimpson,
                margaretSimpson,

            };
            return listSimpsons;
        }

    }

}