﻿using System.ServiceProcess;

namespace Pipeliner.Runner
{
    public partial class PipelinerService : ServiceBase
    {
        public PipelinerService()
        {
            InitializeComponent();
        }

        protected override void OnStop()
        {
        }

        protected override void OnStart(string[] args)
        {
        }
    }
}