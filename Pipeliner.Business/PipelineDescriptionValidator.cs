namespace Pipeliner.Business
{
    public class PipelineDescriptionValidator
    {
        public ValidationResult Validate(PipelineDescription pipelineDescription)
        {
            return new ValidationResult(false);
        }
    }
}