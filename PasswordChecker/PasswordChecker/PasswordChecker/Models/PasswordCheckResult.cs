
using static PasswordChecker.Models.Constants;

namespace PasswordChecker.Models
{
    public class PasswordCheckResult
    {
        public PasswordStrength PasswordStrength { get; set; }
        public string Message { get; set; }
        public int BreachCount { get; set; }

        public PasswordCheckResult()
        {
            Message = string.Empty;
        }
        public override bool Equals(object obj)
        {
            var otherObject = obj as PasswordCheckResult;
            return Message.Equals(otherObject.Message) && PasswordStrength == otherObject.PasswordStrength && BreachCount == otherObject.BreachCount;
        }
    }
}
