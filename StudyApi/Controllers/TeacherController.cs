using Microsoft.AspNetCore.Mvc;
using StudyApi.AddModle;
using StudyApi.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyApi.Controllers
{
    /// 1.string 赋值到 IEnumberable<Guid>  
    /// 2.重写model绑定
    /// 3.post后创建get location，及其Data
    /// 4.可以get和post 访问
    /// 5.使用automapper，这个依赖注入是怎么注入进来的，没有实例吗？
    /// 6.多试试route路由，控制器添加路由\action上添加路由\--------- 添加统一前缀api路由
    /// 7.了解[http(template="？这个是路由？"name="1.这个name是啥？2.nameOf(action名称)这个是啥？")]

    [ApiController]
    [Route("api/Teacher")]
    public class TeacherController : ControllerBase
    {
        TeacherRepository _teacherRepository;
        public TeacherController()
        {
            _teacherRepository = new TeacherRepository();
        }

        [HttpGet("{studentIds}", Name = nameof(GetStudents))]
        ////Name:这个是啥玩意？ nameof是啥？
        public IActionResult GetStudents(
            [FromRoute]
            [ModelBinder(BinderType=typeof(BindModleStringToList))]
            IEnumerable<Guid> studentIds)
        {
            if (studentIds?.Count() == 0)
            {
                return BadRequest();
            }
            IEnumerable<Teacher> teachers = _teacherRepository.GetTeachers(studentIds);
            return Ok(teachers);
        }

        //[HttpGet("{studentIds}", Name = nameof(GetStudents1))]
        ////Name:这个是啥玩意？ nameof是啥？
        //public IActionResult GetStudents1(string studentIds)
        //{
        //    var ids = studentIds.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList();
        //    IList<Guid> idsToGuid = new List<Guid>();
        //    foreach (var item in ids)
        //    {
        //        idsToGuid.Add(new Guid(item));
        //    }
        //    IEnumerable<Teacher> teachers = _teacherRepository.GetTeachers(idsToGuid);
        //    return Ok(teachers);
        //}


        [HttpPost]
        public IActionResult Insert([FromBody] IEnumerable<Teacher> teachers)
        {
            if (teachers?.Count() == 0)
            {
                return BadRequest();
            }
            foreach (var teacher in teachers)
            {
                teacher.Id = Guid.NewGuid();
                foreach (var student in teacher.Students)
                {
                    student.Id = Guid.NewGuid();
                }
            }
            IEnumerable<Teacher> returnTeachers = _teacherRepository.InsertTeachers(teachers);
            var idsString = string.Join(",", returnTeachers.Select(s => s.Id));
            return CreatedAtRoute(nameof(GetStudents), new { studentIds = idsString }, returnTeachers);
        }
    }
}
