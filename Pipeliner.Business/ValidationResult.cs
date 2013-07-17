namespace Pipeliner.Business
{
    public class ValidationResult
    {
        public static ValidationResult Success 
        {
            get { return new ValidationResult(true); }
        }

        public static ValidationResult Invalid(string message = null)
        {
            return new ValidationResult(false, message);
        }

        private ValidationResult(bool isValid, string message = null)
        {
            IsValid = isValid;
            Message = message;
        }

        public bool IsValid { get; private set; }

        public string Message { get; private set; }
    }
}