using System.Collections.Generic;
using FamilyTree;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Client;
using NUnit.Framework;

namespace NUnitTestProject1
{
    public class FamilyAppTest
    {

        [Test]
        public void Test()
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

            var familyList = new List<Person>();
            familyList.Add(abrahamSimpson);
            familyList.Add(monaOlsen);
            familyList.Add(homerSimpson);
            familyList.Add(marjorieSimpson);
            familyList.Add(barthSimpson);
            familyList.Add(lisaSimpson);
            familyList.Add(margaretSimpson);

            var app = new FamilyApp
            {
                Persons = familyList
            };

            var actualResponse = app.HandleCommand("vis 3");
            var expectedResponse = "Homer Simpson (Id:3) Father: Abraham (Id:1) Mother: Mona (Id:2)\n"
                                   + " Children:\n"
                                   + "\tBarth Simpson (Id:5) Father: Homer (Id:3) Mother: Marjorie (Id:4)\n"
                                   + "\tLisa Simpson (Id:6) Father: Homer (Id:3) Mother: Marjorie (Id:4)\n"
            +"\tMargaret Simpson (Id:7) Father: Homer (Id:3) Mother: Marjorie (Id:4)\n";
            Assert.AreEqual(expectedResponse, actualResponse);

            var notExpectedResponse = "no";
            Assert.AreNotEqual(notExpectedResponse, actualResponse);
        }

        [Test]
        public void Test2()
        {
            var abrahamSimpson = new Person { Id = 1, FirstName = "Abraham", LastName = "Simpson", Status = "Alive" };
            var familyList = new List<Person>();

            familyList.Add(abrahamSimpson);
      
            var app = new FamilyApp
            {
                Persons = familyList
            };
            var actualResponse = app.HandleCommand("vis 1");
            var expectedResponse = "Abraham Simpson (Id:1) Father:  (Id:) Mother:  (Id:)";
            Assert.AreEqual(expectedResponse, actualResponse);

            var notExpectedResponse = "no";
            Assert.AreNotEqual(notExpectedResponse, actualResponse);
        }
    }
}