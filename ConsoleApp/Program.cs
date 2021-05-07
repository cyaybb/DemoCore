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
        public int em { get; set; }
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
//什么时候释放 连接？  用依赖注入到UI吗？用哪个生命周期吗？


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
//正：增删改查   一定要去试试！！！！！！！！容易出错
//反：


//----------------------------------------------------------
//有多个继承关系的映射：
//建表：一对一、一对多、一对多(建表可能有多种形式)
//增删改查

//----------------------------------------------------------
//有多个关联对象的时候：
//增删改查
//查关联的表（多对多那个,但是又没存在db < set >）：context.set < 关联类名 >（）.where


//----------------------------------------------------------
//其他：   
//asQuirable

//查：:
//lamuda 里面用sql语句 例如 like %这个求和、就平均值，求最大，最小，排序。取最后一个
//预加载中关联的collection，去过滤
//load()


//区分：add、update、attach和场景

//预先加载、显示加载(只能查单个？)  惰性加载！

//13.最后以asp.net 配置EF启动和在appsettings中配置用依赖注入

//asNoTracking() 用法和使用场景（这个比较消耗性能，不需要追踪的要调用一下）

//e.同时添加 不同类型的数据，context.addrage()或context。add() 这个去看看

//修改数据：分有追踪和没有追踪。

//修改：一个对象a加载和关联对象b加载出来，修改b。当使用另一个context或离线数据的时候，怎么只修改b，而不修改a？用update就是这样。正确答案：（新）context.entry(要修改的对象).state = entityState.Modified


//12.执行原生的sql 语句
//查询类：
//context.表名.FromSqlInterpolated($"sql语句{内插值，变量值}").ToList();
//context.表名.FromSqlRaw($"sql语句{内插值，变量值}").ToList();

//执行非查询类SQL: 返回影响行数
//Context.Database.ExecuteSQLRaw("sql语句")
//Context.Database.ExecuteSQLInterpolated("sql语句")