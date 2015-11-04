using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace APIalumnos
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        //define que hacer cuando la app carga
        protected void Application_Start()
        {

            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
