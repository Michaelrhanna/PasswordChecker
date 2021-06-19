
using static PasswordChecker.Models.Constants;

namespace PasswordChecker.Models
{
    public class PasswordCheckResult
    {
        public PasswordStrength PasswordStrength { get; set; }
        public string Message { get; set; }
        public int BreachCount { get; set; }
    }
}
