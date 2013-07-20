using System;
using System.ServiceProcess;
using Autofac;
using log4net;
using Pipeliner.Business;
using Pipeliner.Runner.Properties;

[assembly: log4net.Config.XmlConfigurator(ConfigFile = "log4net.config", Watch = true)]

namespace Pipeliner.Runner
{
    /// <summary>
    /// The service program.
    /// </summary>
    public static class ServiceProgram
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        public static void Main()
        {
            log4net.Config.XmlConfigurator.Configure();

            AppDomain.CurrentDomain.UnhandledException += OnCurrentDomainOnUnhandledException;
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

        /// <summary>
        /// The get preconfigured container.
        /// </summary>
        /// <returns>
        /// The <see cref="IContainer"/>.
        /// </returns>
        private static IContainer GetPreconfiguredContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterAssemblyTypes(typeof(PipelineRunner).Assembly);
            builder.RegisterType<PipelinerService>();
            var logger = LogManager.GetLogger(typeof(ServiceProgram));
            builder.RegisterInstance(logger).As<ILog>();
            return builder.Build();
        }

        /// <summary>
        /// The on current domain on unhandled exception.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="args">
        /// The args.
        /// </param>
        private static void OnCurrentDomainOnUnhandledException(object sender, UnhandledExceptionEventArgs args)
        {
            var logger = LogManager.GetLogger(typeof(ServiceProgram));

            Action<string, Exception> log = args.IsTerminating
                                                ? new Action<string, Exception>(logger.Fatal)
                                                : logger.Error;

            log(Resources.ServiceProgram_UnhandledExceptionMessage, (Exception)args.ExceptionObject);
        }
    }
}