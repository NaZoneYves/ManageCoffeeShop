using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffee
{
    internal class Employee: Person
    {
        private float baseSalary;
        private string positionEmployee;

        public float BaseSalary { get => baseSalary; set => baseSalary = value; }
        public string PositionEmployee { get => positionEmployee; set => positionEmployee = value; }
        public Employee(string id, string name, float salary, string position) : base(id, name)
        {
            BaseSalary = salary;
            PositionEmployee = position;
        }

        interface ChosseWorkTime
        {
            void ChosseWorkTime();
        }


    }

}
