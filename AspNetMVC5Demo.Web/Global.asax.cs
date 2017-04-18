using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

using AspNetMVC5Demo.Infrastructure.Database;

namespace AspNetMVC5Demo.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Abort tool = new Abort();
            tool.Set(); // 貌似没什么卵用

            MvcHandler.DisableMvcResponseHeader = true;

            AutofacConfig.Build();

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            Utility.LoadHttpModules(this);
        }
    }

    internal class Utility
    {
        internal static void LoadHttpModules(HttpApplication app)
        {
            string path = Path.Combine(HttpRuntime.AppDomainAppPath, "App_Data", "Modules");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            var fileName = Path.Combine(path, "AspNet.txt");
            StreamWriter writer = new StreamWriter(fileName, false, Encoding.UTF8, 1024);

            writer.WriteLine($"一共运行 {app.Modules.Count} 个 IHttpModule");
            foreach (string module in app.Modules.Keys)
            {
                writer.WriteLine(module);
            }

            writer.Close();
            writer.Dispose();
        }
    }
}
