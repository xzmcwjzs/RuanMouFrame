using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace xzmcwjzs.ntu.MVC.UI.Utility.Unity
{
    /// <summary>
    /// 依赖注入的容器工厂
    /// </summary>
    public class DIFactory
    {
        private static IUnityContainer _ObjectContainer;
        public static IUnityContainer ObjectContainer
        {
            get
            {
                if (_ObjectContainer == null)
                {
                    _ObjectContainer = new UnityControllerFactory().UnityContainer;
                }
                return _ObjectContainer;
            }
        }
    }
}