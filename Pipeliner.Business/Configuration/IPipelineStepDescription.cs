namespace Pipeliner.Business.Configuration
{
    public interface IPipelineStepDescription
    {
        IPipelineStepTrigger Trigger { get; set; }

        string Name { get; set; }
    }
}