using System;

namespace Pipeliner.Business
{
    public class PipelineRunner
    {
        private readonly IInstanceCreator instanceCreator;
        private readonly IStorage storage;

        public PipelineRunner(IInstanceCreator instanceCreator, IStorage storage)
        {
            this.instanceCreator = instanceCreator;
            this.storage = storage;
        }

        public void Run(PipelineDescription description)
        {
            description.Starter.OnPipelineInstanceCreate += (sender, args) =>
            {
                var instance = instanceCreator.CreateInstance();
                instance.Context.Parameters.Add(args.Parameters);
                storage.AddPipeline(instance);
            };
        }
    }

    public interface IStorage
    {
        void AddPipeline(PipelineInstance instance);
    }
}