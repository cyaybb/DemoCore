using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Entity
{
    public class Teacher
    {
        public Teacher()
        {
            //Students = new List<Student>();
        }
                
        public int TeacherId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}
