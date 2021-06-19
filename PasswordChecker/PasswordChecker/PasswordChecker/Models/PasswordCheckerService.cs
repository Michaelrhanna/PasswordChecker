using System;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using static PasswordChecker.Models.Constants;


namespace PasswordChecker.Models
{
    public class PasswordCheckerService : IPasswordCheckerService
    {
        const string _Symbols = "~!@#$%^&*()_-+=|\\}{][;:/?><";
        public PasswordCheckResult CheckPassword(string sPassword)
        {
            PasswordCheckResult passwordCheckResult = new PasswordCheckResult();
            //to comply with minimum requirement the password have to be less than the defined MINIMUM Length also must have a capital letter, small letter and a number.
            if (string.IsNullOrEmpty(sPassword) || sPassword.Length < MINIMUM_LENGTH)
            {
                passwordCheckResult.PasswordStrength = PasswordStrength.NoComply;
                passwordCheckResult.Message = string.Format(MESSAGE_SHORT_PASSWORD, MINIMUM_LENGTH);
                passwordCheckResult.BreachCount = 0;
                return passwordCheckResult;
            }

            if(!sPassword.Any(char.IsUpper))
            {
                passwordCheckResult.PasswordStrength = PasswordStrength.NoComply;
                passwordCheckResult.Message = MESSAGE_NO_CAPITAL_LETTERS;
                passwordCheckResult.BreachCount = 0;
                return passwordCheckResult;
            }

            if (!sPassword.Any(char.IsLower))
            {
                passwordCheckResult.PasswordStrength = PasswordStrength.NoComply;
                passwordCheckResult.Message = MESSAGE_NO_SMALL_LETTERS;
                passwordCheckResult.BreachCount = 0;
                return passwordCheckResult;
            }

            if(!sPassword.Any(char.IsDigit))
            {
                passwordCheckResult.PasswordStrength = PasswordStrength.NoComply;
                passwordCheckResult.Message = MESSAGE_NO_NUMBER;
                passwordCheckResult.BreachCount = 0;
                return passwordCheckResult;
            }

            // at this point we know that it is at least MINIMUM_LENGTH and has at least 1 upper case, one lower case and one digit
            passwordCheckResult.PasswordStrength = PasswordStrength.VeryWeak;

            //if we have a special character used then it gets to the next level
            if (sPassword.Any(c=> _Symbols.Contains(c)))
                passwordCheckResult.PasswordStrength++;

            // if it has more characters than minimum and less than Upper limit then that takes it to the next rank
            if(sPassword.Length > MINIMUM_LENGTH )
                passwordCheckResult.PasswordStrength++;

            // if password has more than the upper limit of characters then it is taken another level up
            if (sPassword.Length > UPPER_LENGTH_LIMIT)
                passwordCheckResult.PasswordStrength++;
            passwordCheckResult.BreachCount = CheckPwnedPassword(sPassword);
            return passwordCheckResult;
        }

        public int CheckPwnedPassword(string sPassword)
        {
            string sHash;
            sHash = GetPasswordHash(sPassword);
            string sHashPrefix = sHash.Substring(0, 5);
            string sHashSuffix = sHash.Substring(5);
            string sUrl = string.Format($"https://api.pwnedpasswords.com/range/{sHashPrefix}");
            var result = new HttpClient().GetAsync(sUrl).Result.Content.ReadAsStringAsync().Result;
            var data = result.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);

            var record = data.ToList().Find(r => r.StartsWith(sHashSuffix));
            if (record == null)
                return 0;
            else
            {
                string sCount = record.Substring(record.IndexOf(':') + 1);
                return int.Parse(sCount);
            }
        }

        private static string GetPasswordHash(string sPassword)
        {
            string sHash;
            using (SHA1 sha1Hash = SHA1.Create())
            {
                //From String to byte array
                byte[] sourceBytes = Encoding.UTF8.GetBytes(sPassword);
                byte[] hashBytes = sha1Hash.ComputeHash(sourceBytes);
                sHash = BitConverter.ToString(hashBytes).Replace("-", string.Empty);
            }
            return sHash;
        }
    }
}
