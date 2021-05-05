using System;
using System.Collections.Generic;
using System.Linq;

namespace StudyApi.Controllers
{
    public class TeacherRepository
    {
        public TeacherRepository()
        {
        }

        public IEnumerable<Teacher> GetTeachers(IEnumerable<Guid> teacherIds)
        {
            var result = TeacherRepositoryData._teachers.Where(t => teacherIds.Contains(t.Id));
            return result;
        }

        public Teacher GetTeacher(string teacherId)
        {
            return null;
        }

        public IList<Teacher> GetAllTeachers()
        {
            return null;
        }

        public IEnumerable<Teacher> InsertTeachers(IEnumerable<Teacher> teachers)
        {
            if (teachers == null || teachers.Count() <= 0)
            {
                return null;
            }
            TeacherRepositoryData._teachers.AddRange(teachers);
            return teachers;
        }
    }

    public static class TeacherRepositoryData
    {
        public static List<Teacher> _teachers = new List<Teacher>
            {
                new Teacher { Id=Guid.NewGuid(),Name="叶飞1",Students=new List<Student>{ new Student {Id=Guid.NewGuid(),Name="cy1" }, new Student { Id = Guid.NewGuid(), Name = "cy3" } } },
                new Teacher { Id = Guid.NewGuid(), Name = "叶飞2", Students = new List<Student> { new Student { Id = Guid.NewGuid(), Name = "cy1" }, new Student { Id = Guid.NewGuid(), Name = "cy2" } } },
                new Teacher { Id = Guid.NewGuid(), Name = "叶飞3", Students = new List<Student> { new Student { Id = Guid.NewGuid(), Name = "cy2" }, new Student { Id = Guid.NewGuid(), Name = "cy3" } } },
            };
    }
}