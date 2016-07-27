using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using MVC5RealWorld.Security;

namespace MVC5RealWorld
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
       
      
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
