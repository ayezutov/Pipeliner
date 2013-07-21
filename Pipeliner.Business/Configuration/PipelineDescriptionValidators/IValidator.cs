namespace Pipeliner.Business.PipelineDescriptionValidators
{
    public interface IValidator<in T>
    {
        ValidationResult Validate(T pipeline);
    }
}