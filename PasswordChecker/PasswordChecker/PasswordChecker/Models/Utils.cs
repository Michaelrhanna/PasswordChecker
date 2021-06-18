using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PasswordChecker.Models
{
    public class Utils
    {
        static string PASSWORD_RESULT_NOT_COMPLY = "Password doesn't comply with the requirements";
        static string PASSWORD_RESULT_VERY_WEAK = "Very Weak";
        static string PASSWORD_RESULT_WEAK = "Weak";
        static string PASSWORD_RESULT_MEDIUM = "Medium";
        static string PASSWORD_RESULT_STRONG = "Strong";

        static string MESSAGE_SHORT_PASSWORD = "Password can't be less than 8 charecters";
        static string MESSAGE_NO_CAPITAL_LETTERS = "Password must contain at least 1 captical letter";
        static string MESSAGE_NO_SMALL_LETTERS = "Password must contain at least 1 small letter";
        static string MESSAGE_NO_NUMBER = "Password must contain at least 1 number";
        

    }
}
