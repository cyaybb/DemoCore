using System;
using System.Collections.Generic;

namespace StudyApi.Controllers
{
    public class Teacher
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public IList<Student> Students { get; set; }
    }
}