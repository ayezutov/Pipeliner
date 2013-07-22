namespace Pipeliner.Business.Configuration
{
    public interface IPipelineStepDescription
    {
        IPipelineStepTrigger Trigger { get; set; }
    }
}