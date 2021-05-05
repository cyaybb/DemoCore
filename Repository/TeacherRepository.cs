using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Repository
{
    public class TeacherRepository
    {
        MyContext context;
        public TeacherRepository()
        {
            context = new MyContext();
        }

        public void Get()
        {
            //var context = new MyContext();
        }

        public int Insert(Teacher teacher)
        {
            context.Teacher.Add(teacher);
            return context.SaveChanges();
        }

        public int Delete(int teacherId)
        {
            var context = new MyContext();
            Teacher teacher = context.Teacher
                                     .Include(t => t.Students)
                                     .Where(t => t.TeacherId == teacherId)
                                     .FirstOrDefault();
            if (teacher == null)
                return 0;
            context.Teacher.Remove(teacher);
            return context.SaveChanges();
        }

        public void Update()
        {

        }
    }
}
