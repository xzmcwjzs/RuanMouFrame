using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xzmcwjzs.ntu.Bussiness.Interface;
using xzmcwjzs.ntu.Bussiness.Service;
using xzmcwjzs.ntu.EF.Model.Entities;

namespace _06_IOC
{
    class Program
    {
        static void Main(string[] args)
        {
            // using (JDContext context=new JDContext())
            // {
            //var user= context.User.Find(2);
            //  var category = context.Category.Find(2); 
            // }

            ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap();
            fileMap.ExeConfigFilename = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "ConfigFiles\\UnityConfig.xml");//找配置文件的路径
            Configuration configuration = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
            UnityConfigurationSection section = (UnityConfigurationSection)configuration.GetSection(UnityConfigurationSection.SectionName);

            IUnityContainer container = new UnityContainer();
            section.Configure(container, "xzmcwjzsContainer");

            IUserCategoryService service = container.Resolve<IUserCategoryService>();
                service.ComplexOperation();
        }
    }
}
