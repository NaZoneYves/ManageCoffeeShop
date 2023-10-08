using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffee
{
    internal class Person
    {
        private string idPerson;
        private string namePerson;
        private string phonePerson;

        public string IdPerson { get => idPerson; set => idPerson = value; }
        public string NamePerson { get => namePerson; set => namePerson = value; }
        public string PhonePerson { get => phonePerson; set => phonePerson = value; }

        public Person() { }
        public Person(string id, string name) 
        {
            IdPerson = id;
            NamePerson = name;
        }
    }
}
