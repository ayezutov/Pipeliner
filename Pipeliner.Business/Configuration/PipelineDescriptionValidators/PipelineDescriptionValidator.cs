using System.Collections.Generic;

namespace Pipeliner.Business.PipelineDescriptionValidators
{
    public class PipelineDescriptionValidator : IValidator<PipelineDescription>
    {
        private readonly IEnumerable<IValidator<PipelineDescription>> validators;

        public PipelineDescriptionValidator(IEnumerable<IValidator<PipelineDescription>> validators)
        {
            this.validators = validators;
        }

        public ValidationResult Validate(PipelineDescription pipeline)
        {
            foreach (var validator in validators)
            {
                var result = validator.Validate(pipeline);
                if (!result.IsValid)
                {
                    return result;
                }
            }

            return ValidationResult.Success;
        }
    }
}