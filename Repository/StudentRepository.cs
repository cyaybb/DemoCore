using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Repository
{
    public class StudentRepository
    {

        public void Get()
        {

        }

        public void Insert(Student student)
        {

        }

        public int Delete(int Id)
        {
            var context = new MyContext();
            Student student = context.Student.Where(t => t.StudentId == Id).FirstOrDefault();
            if (student == null)
            {
                return 0;
            }
            context.Student.Remove(student);
            return context.SaveChanges();
        }

        public void Update()
        {

        }
    }
}
