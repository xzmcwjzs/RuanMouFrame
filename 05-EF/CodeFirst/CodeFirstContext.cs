namespace _05_EF.CodeFirst
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using System.Linq;

    public class CodeFirstContext : DbContext
    {
        //您的上下文已配置为从您的应用程序的配置文件(App.config 或 Web.config)
        //使用“CodeFirstContext”连接字符串。默认情况下，此连接字符串针对您的 LocalDb 实例上的
        //“_05_EF.CodeFirst.CodeFirstContext”数据库。
        // 
        //如果您想要针对其他数据库和/或数据库提供程序，请在应用程序配置文件中修改“CodeFirstContext”
        //连接字符串。
        public CodeFirstContext()
            : base("name=CodeFirstContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Database.SetInitializer<CodeFirstContext>(new CreateDatabaseIfNotExists<CodeFirstContext>());
            //Database.SetInitializer<CodeFirstContext>(new DropCreateDatabaseAlways<CodeFirstContext>());
            //Database.SetInitializer<CodeFirstContext>(new DropCreateDatabaseIfModelChanges<CodeFirstContext>());
            Database.SetInitializer<CodeFirstContext>(null);//不检查实体变化
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();//去掉默认的复数

            //映射 三种方式（特性）
            //modelBuilder.Configurations.Add(new xxxMapping());
            //modelBuilder.Entity<xxx>().ToTable("xxx").Property(c => c.xx).HasColumnName("xx");
        }


    }
    
}