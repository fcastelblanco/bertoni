using System;
using Autofac;
using Fgcm.ApplicationService.Definitions;
using Fgcm.IoC;

namespace Fgcm.Module
{
    class Program
    {
        static void Main(string[] args)
        {
            var containerBuilder = new ContainerBuilder();
            var container = containerBuilder.RegisterResources();

            var first = container.Resolve<IGeneralApplicationService>().GetAllPhotos().Result;
            var second = container.Resolve<IGeneralApplicationService>().GetAllAlbums().Result;
            var third = container.Resolve<IGeneralApplicationService>().GetAllComments().Result;
        }
    }
}
