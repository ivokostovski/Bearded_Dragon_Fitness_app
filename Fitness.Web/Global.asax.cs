using System.Web.Mvc;
using System.Web.Routing;
using Fitness.Services;

namespace Fitness.Web
{
    using System.Configuration;

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        
            //FitnessManager.InitializeDatabase();
        }
    }
}
