using System.ServiceProcess;
using Pipeliner.Business;
using Pipeliner.Communication;

namespace Pipeliner.Runner
{
    public partial class PipelinerService : ServiceBase
    {
        private readonly ApplicationRunner application;
        private readonly PipelinerCommunicationRunner communication;

        public PipelinerService(ApplicationRunner application, PipelinerCommunicationRunner communication)
        {
            this.application = application;
            this.communication = communication;
            InitializeComponent();
        }

        protected override void OnStop()
        {
            application.Stop();
            communication.Stop();
        }

        protected override void OnStart(string[] args)
        {
            application.Run();
            communication.Run();
        }
    }
}
