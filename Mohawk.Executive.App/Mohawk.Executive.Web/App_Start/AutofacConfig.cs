using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Mohawk.Executive.Services.Interfaces;
using Mohawk.Executive.Services.Services;

// ReSharper disable once CheckNamespace
namespace Mohawk.Executive.Web.App_Start
{
    public class AutofacConfig
    {
        public static void RegisterAutofac()
        {
            var builder = new ContainerBuilder();

            // Register your MVC controllers. (MvcApplication is the name of
            // the class in Global.asax.)
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            builder.RegisterType<ContactService>().As<IContactHanlder>();
            builder.RegisterType<OpportunityService>().As<IOpportunityHandler>();
            builder.RegisterType<DonationService>().As<IDonationHandler>();

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}