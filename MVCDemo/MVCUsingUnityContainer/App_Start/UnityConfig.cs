using System.Web.Mvc;
using Unity;
using Unity.Mvc5;
using EntitiesCL;
using ServicesCL;

namespace MVCUsingUnityContainer
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IInstitutionServices, InstitutionServices>();
            container.RegisterType<ICourseService, CourseService>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}