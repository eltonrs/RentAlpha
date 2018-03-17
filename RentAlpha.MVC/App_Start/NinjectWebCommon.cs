[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(RentAlpha.MVC.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(RentAlpha.MVC.App_Start.NinjectWebCommon), "Stop")]

namespace RentAlpha.MVC.App_Start
{
  using System;
  using System.Web;

  using Microsoft.Web.Infrastructure.DynamicModuleHelper;

  using Ninject;
  using Ninject.Web.Common;
  using Ninject.Web.Common.WebHost;
  using RentAlpha.Application.Interfaces;
  using RentAlpha.Application.Services;
  using RentAlpha.Domain.Interfaces.Repositories;
  using RentAlpha.Domain.Interfaces.Services;
  using RentAlpha.Domain.Services;
  using RentAlpha.Infrastructure.Data.Repositories;

  public static class NinjectWebCommon
  {
    private static readonly Bootstrapper bootstrapper = new Bootstrapper();

    /// <summary>
    /// Starts the application
    /// </summary>
    public static void Start()
    {
      DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
      DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
      bootstrapper.Initialize(CreateKernel);
    }

    /// <summary>
    /// Stops the application.
    /// </summary>
    public static void Stop()
    {
      bootstrapper.ShutDown();
    }

    /// <summary>
    /// Creates the kernel that will manage your application.
    /// </summary>
    /// <returns>The created kernel.</returns>
    private static IKernel CreateKernel()
    {
      var kernel = new StandardKernel();
      try
      {
        kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
        kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

        RegisterServices(kernel);
        return kernel;
      }
      catch
      {
        kernel.Dispose();
        throw;
      }
    }

    /// <summary>
    /// Load your modules or register your services here!
    /// </summary>
    /// <param name="kernel">The kernel.</param>
    private static void RegisterServices(IKernel kernel)
    {
      // o conteúdo abaixo é vinculado manualmente:

      // os que estão usando "typeof" é que são de classe genéricas<>

      // Application
      kernel.Bind(typeof(IAppServiceBase<>)).To(typeof(AppServiceBase<>));
      kernel.Bind<IAppServiceFriend>().To<AppServiceFriend>();
      kernel.Bind<IAppServiceGame>().To<AppServiceGame>();

      kernel.Bind(typeof(IServiceBase<>)).To(typeof(ServiceBase<>));
      kernel.Bind<IServiceFriend>().To<ServiceFriend>();
      kernel.Bind<IServiceGame>().To<ServiceGame>();

      kernel.Bind(typeof(IRepositoryBase<>)).To(typeof(RepositoryBase<>));
      kernel.Bind<IRepositoryFriend>().To<RepositoryFriend>();
      kernel.Bind<IRepositoryGame>().To<RepositoryGame>();
    }
  }
}
