using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegats_events_and_LINQ
{
    public class Student
    {
        public string Name { get; set; } // Имя
        public List<int> Grades { get; set; } // Список оценок

        public class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }
    }
}
