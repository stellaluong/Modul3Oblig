using System;
using System.Collections;
using System.Collections.Generic;


namespace FamilyTree
{
    public class FamilyApp
    {
        public List<Person> Persons { get; set; }

        public string HandleCommand(string input)
        {
            string response = null;
            string idAsString = null;
            Person person = null;

            idAsString = input.Replace("vis ", "");

            if (!int.TryParse(idAsString, out int id))
                throw new Exception("Not a valid integer input.");


            foreach (var p in Persons)
            {
                if (p.Id == id)
                {
                    person = p;
                    response = person.GetDescription();
                }
            }

            if (person == null)
                throw new Exception($"No person in the list has an id of {id}");

            List<Person> children = new List<Person>();

            foreach (var p in Persons)
            {
                if (p.Father != null && p.Father.Id == person.Id || p.Mother != null && p.Mother.Id == person.Id)
                    children.Add(p);
            }

            if (children.Count == 0)
                return response;

            string childrenString = string.Empty;

            foreach (var c in children)
            {
                childrenString = $"{childrenString}\t{c.GetDescription()}\n";
            }

            return $"{response}\n Children:\n{childrenString}";



            //var homer = $"{FirstName} (Id={Id}) {Status}: Alive Father: {Father?.FirstName} (Id:{Father?.Id})\n "
            //            + "Children:\n"
            //            + $"{FirstName} (Id={Id} {Status}: Alive\n"
            //            + $"{FirstName} (Id={Id} {Status}: Alive\n";
            //return homer;
        }
    }
}