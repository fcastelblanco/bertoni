using System;
using Autofac;
using Fgcm.ApplicationService.Definitions;
using Fgcm.ApplicationService.Implementations;
using Fgcm.Data.Definitions;
using Fgcm.Data.Implementations;

namespace Fgcm.IoC
{
    public static class MainCointainer
    {
        public static IContainer RegisterResources(this ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<ClientRestRepository>().As<IClientRestRepository>();
            containerBuilder.RegisterType<GeneralApplicationService>().As<IGeneralApplicationService>();
            

            return containerBuilder.Build();
        }

        public static ContainerBuilder FillContainer(this ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<ClientRestRepository>().As<IClientRestRepository>();
            containerBuilder.RegisterType<GeneralApplicationService>().As<IGeneralApplicationService>();


            return containerBuilder;
        }
    }
}
