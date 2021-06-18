using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PasswordChecker.Models
{
    public class PasswordCheckerService : IPasswordCheckerService
    {
        public PasswordCheckResult CheckPassword(string password)
        {
            PasswordCheckResult passwordCheckResult = new PasswordCheckResult();

            return passwordCheckResult;
        }
    }
}
