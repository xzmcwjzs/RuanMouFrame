using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System.Configuration;
using System.IO;

namespace xzmcwjzs.ntu.MVC.UI.Utility.Unity
{
    public class UnityControllerFactory : DefaultControllerFactory
    {
        private static object syncHelper = new object();
        //静态字典
        static Dictionary<string, IUnityContainer> UnityContainerDictionary = new Dictionary<string, IUnityContainer>();
        public IUnityContainer UnityContainer { get; set; }

        public UnityControllerFactory()
        {
            string containerName = "xzmcwjzsContainer";
            if (UnityContainerDictionary.ContainsKey(containerName))
            {
                this.UnityContainer = UnityContainerDictionary[containerName];
                return;
            }
            else
            {
                lock (syncHelper)
                {
                    if (UnityContainerDictionary.ContainsKey(containerName))
                    {
                        this.UnityContainer = UnityContainerDictionary[containerName];
                        return;
                    }
                    else
                    {
                        //配置UnityContainer
                        IUnityContainer container = new UnityContainer();

                        ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap();
                        fileMap.ExeConfigFilename = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "ConfigFiles\\UnityConfig.xml");
                        Configuration configuration = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
                        UnityConfigurationSection configSection = (UnityConfigurationSection)configuration.GetSection(UnityConfigurationSection.SectionName);
                        configSection.Configure(container, "xzmcwjzsContainer");

                        UnityContainerDictionary.Add(containerName, container);
                        this.UnityContainer = UnityContainerDictionary[containerName];
                    }
                }
            }
        }

        /// <summary>
        /// 创建控制器对象
        /// </summary>
        /// <param name="requestContext"></param>
        /// <param name="controllerType"></param>
        /// <returns></returns>
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if (null == controllerType)
            {
                return null;
            }
            return (IController)this.UnityContainer.Resolve(controllerType);
        }
        public override void ReleaseController(IController controller)
        {
            this.UnityContainer.Teardown(controller);
        }
    }
}