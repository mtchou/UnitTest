using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClasses.PersonClasses
{
    public class PersonManager
    {

        public Person CreatePerson(string first, string last, bool isSupervisor)
        {
            Person ret = null;
            if (!string.IsNullOrEmpty(first))
            {
                if (isSupervisor)
                {
                    ret = new Supervisor();
                }
                else
                {
                    ret = new Employee();
                }
                ret.FirstName = first;
                ret.LastName = last;
            }
            return ret;
        }

        public List<Person> GetPeople()
        {
            List<Person> listPeople = new List<Person>();
            listPeople.Add(new Person() { FirstName = "Mandy", LastName = "Chou" });
            listPeople.Add(new Person() { FirstName = "Ashwini", LastName = "Suloch" });
            listPeople.Add(new Person() { FirstName = "Alan", LastName = "Wong" });
            return listPeople;
        }


        public List<Person> GetSupervisor()
        {
            List<Person> listPeople = new List<Person>();
            listPeople.Add(CreatePerson ("Yolanda", "Sam", true ));
            listPeople.Add(CreatePerson( "Sian", "Doherty", true ));
            return listPeople;
        }

        public List<Person> GetEmployee()
        {
            List<Person> listPeople = new List<Person>();
            listPeople.Add(CreatePerson("intern", "A", false));
            listPeople.Add(CreatePerson("intern", "B", false));
            listPeople.Add(CreatePerson("intern", "C", false));
            return listPeople;
        }

        public List<Person> GetSupervisorsAndEmployees()
        {
            List<Person> listPeople = new List<Person>();

            listPeople.AddRange(GetEmployee());
            listPeople.AddRange(GetSupervisorsAndEmployees());

            return listPeople;
        }
    }

}
