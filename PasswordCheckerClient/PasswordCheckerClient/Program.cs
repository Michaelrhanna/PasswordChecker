using IO.Swagger.Client;
using IO.Swagger.Api;
using System;

namespace PasswordCheckerClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Password Checker API tester console application");
            Console.WriteLine("Please run the API project locally and copy and paste the URL of the running project. i.e.: https://localhost:44333/");
            var url = Console.ReadLine();
            TestAPIConncetion(url);
        }

        private static void TestAPIConncetion(string url)
        {
            APIApi api = new APIApi();
            api.Configuration.BasePath = url;

            api.TestConncetionGet();
        }
    }
}
