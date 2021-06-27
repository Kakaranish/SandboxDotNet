using System.Collections.Generic;

namespace Yield
{
    public class YieldWorkspace
    {
        public IEnumerable<Person> GetPeople(int count)
        {
            var people = new List<Person>();

            for (int i = 0; i < count; i++)
            {
                var person = new Person
                {
                    Id = i,
                    Name = $"Person {i}"
                };
                people.Add(person);
            }

            return people;
        }

        public IEnumerable<Person> GetPeopleWithYield(int count)
        {
            for (int i = 0; i < count; i++)
            {
                var person = new Person
                {
                    Id = i,
                    Name = $"Person {i}"
                };
                
                yield return person;
            }
        }
    }
}
