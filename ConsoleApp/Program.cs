using Domain.Entity;
using Domain.Repository;
using System;
using System.Collections.Generic;

namespace ConsoleApp
{
    class Program
    {
        /// <summary>
        /// 执行结果的数量
        /// </summary>
        static int excute = 0;

        static void Main(string[] args)
        {
            //excute = ExcuteMethod.Insert();

            //excute = new TeacherRepository().Delete(1);
            //excute = new StudentRepository().Delete(4);



            Console.WriteLine($"成功数量：{excute}");
        }
    }

    class ExcuteMethod
    {
        public static int Insert()
        {
            //一对多
            Student cbw = new Student();
            cbw.Name = "陈百万";

            Student aw = new Student();
            aw.Name = "阿伟";

            Student zlh = new Student();
            zlh.Name = "周林浩";

            Teacher teacher = new Teacher();
            teacher.Name = "陈百万";
            teacher.Students = new List<Student> { cbw, aw, zlh };
            return new TeacherRepository().Insert(teacher);
        }

        public static int Delete(int index)
        {
            return new TeacherRepository().Delete(index);
        }
    }

}
// 一对多情况： 
//正：一开始：
//1.api设置、annotation(表名、字段类型转换、约束、主键、联合主键、不映射到数据库)
//2.增：
//3.删：级联
//4.改：在线数据、不在线数据   attach
//5.查：预先加载()，延迟加载；SQL(语句去查询)； 
//反：多开始：


//---------------------------------------------------------
//一对1(假设不设置外键和主从表=》和我用api去设置主从表=》看会不会改变 主从表的外键在那个表上面)
//正：
//反：


//----------------------------------------------------------
//多对多情况：(这个也试试 外键的 api，看文档配置和用api需不需设置主从表)
//建表：(建关联表=>要不要Dbset<>)
//正：
//反：


//----------------------------------------------------------
//有多个继承关系的映射：
//建表：一对一、一对多、一对多(建表可能有多种形式)
//增删改查

//----------------------------------------------------------
//有多个关联对象的时候：
//增删改查


//----------------------------------------------------------













