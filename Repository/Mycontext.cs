using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;

namespace Domain.Repository
{
    public class MyContext : DbContext
    {

        public static readonly ILoggerFactory ConsoleLoggerFactory = LoggerFactory.Create(buider =>
        {
            //buider.AddFilter(
            //    (category, level) =>
            //        category == DbLoggerCategory.Database.Command.Name
            //        && level == LogLevel.Information
            //    ).AddConsole();

            buider
                   .AddFilter(// 添加日志过滤条件
                    (category, level) =>
                        category == DbLoggerCategory.Database.Command.Name
                        && level == LogLevel.Information
                    )
                  .AddConsole();//日志输出到控制台
        });

        //一对多
        public DbSet<Teacher> Teacher { get; set; }
        public DbSet<Student> Student { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Teacher>()
                .HasMany(t => t.Students)
                .WithOne(s => s.Teacher)
                .OnDelete(DeleteBehavior.Cascade);//配置级联删除，Teacher为主表，Students为从表。删除teacher会把所有的student删除
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //mssql
            //optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=Study20210503;User ID=sa;Password=123456;" +
            //    "Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
            //    .EnableSensitiveDataLogging().LogTo(s => Console.WriteLine(s)/*, LogLevel.Information*/);

            //mysql
            optionsBuilder
                .UseLoggerFactory(ConsoleLoggerFactory)//使日志信息输出到控制台
                .EnableSensitiveDataLogging()//让日志信息中 查询的参数值可以输出到日志
                .UseMySql("server=127.0.0.1;user id=root;Password=root;persistsecurityinfo=True;database=study1");
        }
    }
}
