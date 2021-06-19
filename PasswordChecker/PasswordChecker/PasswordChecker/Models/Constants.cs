using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PasswordChecker.Models
{
    public static class Constants
    {
        public enum PasswordStrength
        {
            NoComply = 0,
            VeryWeak = 1,
            Weak = 2,
            Medium = 3,
            Strong = 4
        }
       

        public static string MESSAGE_SHORT_PASSWORD = "Password can't be less than {0} charecters";
        public static string MESSAGE_NO_CAPITAL_LETTERS = "Password must contain at least 1 captical letter";
        public static string MESSAGE_NO_SMALL_LETTERS = "Password must contain at least 1 small letter";
        public static string MESSAGE_NO_NUMBER = "Password must contain at least 1 number";

        public static int MINIMUM_LENGTH = 6;
        public static int UPPER_LENGTH_LIMIT = 8;

    }
}
