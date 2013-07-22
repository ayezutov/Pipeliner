using Pipeliner.Business.Configuration;
using Pipeliner.Business.Properties;

namespace Pipeliner.Business.PipelineDescriptionValidators
{
    public class PipelineDescriptionValidatorForImmediateFields : IValidator<PipelineDescription>
    {
        public ValidationResult Validate(PipelineDescription pipeline)
        {
            if (pipeline == null)
            {
                return ValidationResult.Invalid(Resources.PipelineDescriptionValidation_IsNull);
            }

            if (pipeline.Name == null)
            {
                return ValidationResult.Invalid(Resources.PipelineDescriptionValidation_NameShouldBeNotEmpty);
            }

            if (pipeline.Starter == null)
            {
                return ValidationResult.Invalid(string.Format(Resources.PipelineDescriptionValidation_StarterIsRequired, pipeline.Name));
            }

            return ValidationResult.Success;
        }
    }
}