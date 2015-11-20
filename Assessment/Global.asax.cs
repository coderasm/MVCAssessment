using System.Web.Mvc;
using System.Web.Routing;
using Assessment.Domain.Repositories;

namespace Assessment
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            DataSeeder.seed(DependencyResolver.Current.GetService<ICustomerRepository>());
            UnityWebActivator.Start();
        }
    }
}
