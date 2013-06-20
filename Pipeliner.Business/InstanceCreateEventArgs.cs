using System;
using System.Collections.Generic;

namespace Pipeliner.Business
{
    public class InstanceCreateEventArgs : EventArgs
    {
        public InstanceCreateEventArgs()
        {
            Parameters = new Dictionary<string, string>();
        }

        public IDictionary<string, string> Parameters { get; private set; }
    }
}