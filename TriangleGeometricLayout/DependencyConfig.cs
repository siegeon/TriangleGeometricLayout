using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using SimpleInjector.Integration.WebApi;
using TriangleGeometricLayout.BLL.Abstract;
using TriangleGeometricLayout.BLL.Concrete;

namespace TriangleGeometricLayout
{
    public class DependencyConfig
    {
        public static void RegisterDependencies()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            container.Register<ITriangleCalculator, TriangleCalculator>(Lifestyle.Scoped);
            container.Register<IInputValidator, InputValidator>(Lifestyle.Scoped);

            container.RegisterMvcControllers(Assembly.GetExecutingAssembly()); // This is an extension method from the integration package.
            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);


            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
        }
    }
}