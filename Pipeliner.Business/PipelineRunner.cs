namespace Pipeliner.Business
{
    public class PipelineRunner
    {
        private readonly IInstanceCreator instanceCreator;

        public PipelineRunner(IInstanceCreator instanceCreator)
        {
            this.instanceCreator = instanceCreator;
        }

        public void Run(PipelineDescription description)
        {
            description.Starter.OnPipelineInstanceCreate += (sender, args) =>
            {
                var instance = instanceCreator.CreateInstance();
            };
        }
    }
}