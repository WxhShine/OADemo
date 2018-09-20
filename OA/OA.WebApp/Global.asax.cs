using log4net;
using OA.WebApp.Models;
using Spring.Web.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace OA.WebApp {
    public class MvcApplication : SpringMvcApplication {
        protected void Application_Start() {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            log4net.Config.XmlConfigurator.Configure();//读取配置信息
            string filePath = Server.MapPath("/Log/");
            ThreadPool.QueueUserWorkItem((a) => {
                while (true) {
                    //判断队列有无数据
                    if (MyExceptionAttribute.ExecptionQueue.Count > 0) {
                        var ex = MyExceptionAttribute.ExecptionQueue.Dequeue();
                        if (ex != null) {
                            //string fileName = DateTime.Now.ToString("yyyy-MM-dd");
                            //File.AppendAllText(filePath + fileName+".txt", ex.ToString(), Encoding.UTF8);
                            ILog logger = LogManager.GetLogger("errorMsg");
                            logger.Error(ex.ToString());
                        }
                    } else {
                        //队列没有数据
                        Thread.Sleep(3000);
                    }
                }
            }, filePath);
        }
    }
}
