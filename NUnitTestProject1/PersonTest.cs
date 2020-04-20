using FamilyTree;
using NUnit.Framework;

namespace NUnitTestProject1
{
    public class PersonTest
    {
        [Test]
        public void TestAllFields()
        {
            var person = new Person
            {
                Id = 17,
                FirstName = "Barth",
                LastName = "Simpsons",
                Father = new Person() {Id = 23, FirstName = "Homer"},
                Mother = new Person() {Id = 29, FirstName = "Marjorie"},
            };
            object actualDescription = person.GetDescription();
            var expectedDescription = "Barth Simpsons (Id:17) Father: Homer (Id:23) Mother: Marjorie (Id:29)";

            Assert.AreEqual(expectedDescription, actualDescription);
        }

        [Test]
        public void TestNoFields()
        {
            var person = new Person
            {
                Id = 1,
            };
            object actualDescription = person.GetDescription();
            var expectedDescription = "(Id:1)";

            Assert.AreEqual(expectedDescription, actualDescription);
        }
    }
}