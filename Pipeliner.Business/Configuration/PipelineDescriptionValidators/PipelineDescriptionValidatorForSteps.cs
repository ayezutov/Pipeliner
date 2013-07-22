using System.Linq;
using Pipeliner.Business.Configuration;
using Pipeliner.Business.Properties;

namespace Pipeliner.Business.PipelineDescriptionValidators
{
    public class PipelineDescriptionValidatorForSteps : IValidator<PipelineDescription>
    {
        public ValidationResult Validate(PipelineDescription pipeline)
        {
            if (pipeline.Steps == null || pipeline.Steps.Count == 0)
            {
                return ValidationResult.Invalid(string.Format(Resources.PipelineDescriptionValidator_PipelineShouldHaveAtLeastOneStep, pipeline.Name));
            }

            if (pipeline.Steps.First().Trigger != null)
            {
                return ValidationResult.Invalid(string.Format(Resources.PipelineDescriptionValidator_PipelineFirstStepShouldHaveNoTriggerDefined, pipeline.Name));
            }

            return ValidationResult.Success;
        }
    }
}