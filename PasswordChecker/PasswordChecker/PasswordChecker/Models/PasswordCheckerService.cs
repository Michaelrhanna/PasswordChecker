using System.Linq;
using static PasswordChecker.Models.Constants;

namespace PasswordChecker.Models
{
    public class PasswordCheckerService : IPasswordCheckerService
    {
        const string _Symbols = "~!@#$%^&*()_-+=|\\}{][;:/?><";
        public PasswordCheckResult CheckPassword(string password)
        {
            PasswordCheckResult passwordCheckResult = new PasswordCheckResult();
            //to comply with minimum requirement the password have to be less than the defined MINIMUM Length also must have a capital letter, small letter and a number.
            if (string.IsNullOrEmpty(password) || password.Length < MINIMUM_LENGTH)
            {
                passwordCheckResult.PasswordStrength = PasswordStrength.NoComply;
                passwordCheckResult.Message = string.Format(MESSAGE_SHORT_PASSWORD, MINIMUM_LENGTH);
                return passwordCheckResult;
            }

            if(!password.Any(char.IsUpper))
            {
                passwordCheckResult.PasswordStrength = PasswordStrength.NoComply;
                passwordCheckResult.Message = MESSAGE_NO_CAPITAL_LETTERS;
                return passwordCheckResult;
            }

            if (!password.Any(char.IsLower))
            {
                passwordCheckResult.PasswordStrength = PasswordStrength.NoComply;
                passwordCheckResult.Message = MESSAGE_NO_SMALL_LETTERS;
                return passwordCheckResult;
            }

            if(!password.Any(char.IsDigit))
            {
                passwordCheckResult.PasswordStrength = PasswordStrength.NoComply;
                passwordCheckResult.Message = MESSAGE_NO_NUMBER;
                return passwordCheckResult;
            }

            // at this point we know that it is at least MINIMUM_LENGTH and has at least 1 upper case, one lower case and one digit
            passwordCheckResult.PasswordStrength = PasswordStrength.VeryWeak;

            //if we have a special character used then it gets to the next level
            if (password.Any(c=> _Symbols.Contains(c)))
                passwordCheckResult.PasswordStrength++;

            // if it has more characters than minimum and less than Upper limit then that takes it to the next rank
            if(password.Length >= MINIMUM_LENGTH )
                passwordCheckResult.PasswordStrength++;

            // if password has more than the upper limit of characters then it is taken another level up
            if (password.Length > UPPER_LENGTH_LIMIT)
                passwordCheckResult.PasswordStrength++;

            return passwordCheckResult;
        }
    }
}
