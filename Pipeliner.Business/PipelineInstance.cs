using System.Collections;
using System.Collections.Generic;

namespace Pipeliner.Business
{
    public class PipelineInstance
    {
        public PipelineInstance()
        {
            Context = new PipelineInstanceContext();
        }

        public PipelineInstanceContext Context { get; set; }
    }

    public class PipelineInstanceContext
    {
        public PipelineInstanceContext()
        {
            Parameters = new ParametersCollection();
        }

        public ParametersCollection Parameters { get; private set; }
    }

    public class ParametersCollection
    {
        readonly Dictionary<string, string> parameters = new Dictionary<string, string>();

        public void Add(IDictionary<string, string> @params)
        {
            foreach (var param in @params)
            {
                parameters.Add(param.Key, param.Value);
            }
        }

        public string this[string parameterName]
        {
            get { return parameters[parameterName]; }
        }
    }
}