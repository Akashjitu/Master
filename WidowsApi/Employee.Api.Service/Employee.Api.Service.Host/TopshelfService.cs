using System;
using System.IO;
using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using Employee.Service.DataBaseAccessObject.Saver;
using Employee.Service.Manager;
using Employee.Service.Models;
using Employee.Service.Service;
using Employee.Service.ServiceConsumer;
using Microsoft.Owin.Hosting;
using Owin;

namespace Employee.Api.Service.Host
{
    internal class TopshelfService
    {
        private IDisposable _webapp;

        public TopshelfService()
        {
        }

        public bool Start()
        {
            _webapp = WebApp.Start<Startup>(url: "http://localhost:8080/");
            Console.WriteLine("url: http://localhost:8080/Api");
            return true;
        }

        public void Stop()
        {
            _webapp?.Dispose();
        }
    }

    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {

            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();
            
            config.Routes.MapHttpRoute(
                 name: "DefaultApi",
                routeTemplate: "api/{controller}/{Id}",
                defaults: new { id = RouteParameter.Optional }
                );

            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
           

            var assemblyType = typeof(EmployeeInfo).GetTypeInfo();

            builder.RegisterAssemblyTypes(assemblyType.Assembly)
            .Where(t => t.Name.EndsWith("Service"))
            .AsImplementedInterfaces()
            .InstancePerRequest();

            builder.RegisterWebApiFilterProvider(config); 
            builder.RegisterType<EmployeeService>().As<IEmployeeService>().InstancePerRequest();
            builder.RegisterType<EmployeeServiceManage>().As<IEmployeeServiceManage>().InstancePerRequest();
            builder.RegisterType<ApiServiceConsumer>().As<IApiServiceConsumer>().InstancePerRequest();
            builder.RegisterType<SeviceDataSave>().As<ISeviceDataSave>().InstancePerRequest();
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            appBuilder.UseAutofacMiddleware(container);
            appBuilder.UseWebApi(config);

        }
    }
}
