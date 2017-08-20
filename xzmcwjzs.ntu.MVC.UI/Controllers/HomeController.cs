using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using xzmcwjzs.ntu.Bussiness.Interface;
using xzmcwjzs.ntu.EF.Model.Entities;
using xzmcwjzs.ntu.MVC.UI.Utility.Filter;
using xzmcwjzs.ntu.MVC.UI.Utility.Unity;

namespace xzmcwjzs.ntu.MVC.UI.Controllers
{
    public class HomeController : Controller
    {
        private IUserService userService = null;
        public HomeController(IUserService userService)
        {
            this.userService = userService;
        }
        public ActionResult Index()
        {
            return View();
        }
        //[AuthorityFilter]
        public ActionResult Index2()
        {
            {
                ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap();
                fileMap.ExeConfigFilename = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "ConfigFiles\\UnityConfig.xml");//找配置文件的路径
                Configuration configuration = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
                UnityConfigurationSection section = (UnityConfigurationSection)configuration.GetSection(UnityConfigurationSection.SectionName);
                IUnityContainer container = new UnityContainer();
                section.Configure(container, "xzmcwjzsContainer");

                IUserService userService = container.Resolve<IUserService>(); //container   
                //IUserService userService = new UserService();
                User user = userService.Find(2);
            }
            {
                IUserService userService = DIFactory.ObjectContainer.Resolve<IUserService>(); //container   
                User user = userService.Find(2);
            }

            {
                User user = userService.Find(2);
            }
            return View("~/Views/Home/Index2.cshtml");
        }
         

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ViewResult RazorShow()
        {
            return View();
        }

        public ViewResult Render(string name)
        {
            ViewBag.Name = name;
            return View();
        }
    }
}