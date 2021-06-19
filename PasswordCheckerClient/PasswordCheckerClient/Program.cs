using IO.Swagger.Client;
using IO.Swagger.Api;
using System;

namespace PasswordCheckerClient
{
    class Program
    {
        public static string PASSWORD_RESULT_NOT_COMPLY = "Password doesn't comply with the requirements";
        public static string PASSWORD_RESULT_VERY_WEAK = "Very Weak";
        public static string PASSWORD_RESULT_WEAK = "Weak";
        public static string PASSWORD_RESULT_MEDIUM = "Medium";
        public static string PASSWORD_RESULT_STRONG = "Strong";

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Password Checker API tester console application >");
            Console.WriteLine("Please run the API project locally and copy and paste the URL of the running project. i.e.: https://localhost:44333/ >");
            Console.Write("Enter URL > ");

            var url = Console.ReadLine();
            int retryCount = 4;
            bool bConnected = false;
            do
            {
               
                if (TestAPIConncetion(url))
                {
                    bConnected = true;
                    break;
                }

                Console.WriteLine($"Failed to connect to:{url} >\n\rYou have {retryCount} more retries/retry. >");
                Console.Write("Enter URL > ");
                url = Console.ReadLine(); 
                retryCount--;
            }
            while (retryCount >= 1);
            if (!bConnected)
            {
                Console.WriteLine("Failed to connect to the API url. Please make sure that you copy the right url. >");
                return;
            }

            string sAnotherPassword = "Y";

            while (sAnotherPassword == "Y")
            {
                Console.Write("Enter Password > ");
                var password = Console.ReadLine();
                CheckPassword(password, url);
                Console.Write("Check another password?(Y/N) > ");
                var key = Console.ReadKey();
                if (key.KeyChar == 'Y' || key.KeyChar == 'y')
                {
                    sAnotherPassword = "Y";
                    Console.WriteLine();
                }
                else
                    sAnotherPassword = "N";
            }

        }

        private static void CheckPassword(string password, string url)
        {
            try
            {
                APIApi api = new APIApi();
                api.Configuration.BasePath = url;
                var result = api.CheckPasswordGet(password);
                Console.Write("Password Strength: ");
                switch(result.PasswordStrength)
                {
                    case IO.Swagger.Model.PasswordStrength.NoComply:
                        {
                            Console.WriteLine(PASSWORD_RESULT_NOT_COMPLY + " >");
                            break;
                        }
                    case IO.Swagger.Model.PasswordStrength.VeryWeak:
                        {
                            Console.WriteLine(PASSWORD_RESULT_VERY_WEAK + " >");
                            break;
                        }
                    case IO.Swagger.Model.PasswordStrength.Weak:
                        {
                            Console.WriteLine(PASSWORD_RESULT_WEAK + " >");
                            break;
                        }
                    case IO.Swagger.Model.PasswordStrength.Medium:
                        {
                            Console.WriteLine(PASSWORD_RESULT_MEDIUM + " >");
                            break;
                        }
                    case IO.Swagger.Model.PasswordStrength.Strong:
                        {
                            Console.WriteLine(PASSWORD_RESULT_STRONG + " >");
                            break;
                        }
                }
                if (!string.IsNullOrEmpty(result.Message))
                {
                    Console.WriteLine(result.Message + " >");
                    
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " >");
            }
            
        }

        private static bool TestAPIConncetion(string url)
        {
            
            try
            {
                APIApi api = new APIApi();
                api.Configuration.BasePath = url;
                var result = api.TestConncetionGetWithHttpInfo();
                if (result.StatusCode == 200)
                {
                    Console.WriteLine(result.Data + " >");
                    return true;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " >");
            }
            return false;

        }
    }
}
