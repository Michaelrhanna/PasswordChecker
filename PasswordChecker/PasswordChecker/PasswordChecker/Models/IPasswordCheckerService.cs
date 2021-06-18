using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PasswordChecker.Models
{
    public interface IPasswordCheckerService
    {
        PasswordCheckResult CheckPassword(string password);
    }
}
