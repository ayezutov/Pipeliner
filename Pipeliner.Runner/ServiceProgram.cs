using System;
using System.ServiceProcess;
using Autofac;
using Pipeliner.Business;
using Pipeliner.Runner.Properties;

namespace Pipeliner.Runner
{
    public static class ServiceProgram
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        public static void Main()
        {
            var container = GetPreconfiguredContainer();

            if (Environment.UserInteractive)
            {
                container.Resolve<ApplicationRunner>().Run();

                Console.WriteLine(Resources.ServiceProgram_HintForExit);
                do
                {
                } while (Console.ReadLine() != "exit");
            }
            else
            {
                ServiceBase.Run(new ServiceBase[]
                                    {
                                        container.Resolve<PipelinerService>()
                                    });
            }
        }

        public static IContainer GetPreconfiguredContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterAssemblyTypes(typeof(PipelineRunner).Assembly);
            builder.RegisterType<PipelinerService>();
            return builder.Build();
        }
    }
}
