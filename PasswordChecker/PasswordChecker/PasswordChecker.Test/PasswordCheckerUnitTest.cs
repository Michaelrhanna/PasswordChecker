using Microsoft.VisualStudio.TestTools.UnitTesting;
using PasswordChecker.Models;

namespace PasswordChecker.Test
{
    [TestClass]
    public class PasswordCheckerUnitTest
    {
        [TestMethod]
        public void TestBlankPassword()
        {
            var apiService = new PasswordCheckerService();
            var result = apiService.CheckPassword(string.Empty);
            Assert.AreEqual(result, new PasswordCheckResult() { PasswordStrength = Constants.PasswordStrength.NoComply, Message = string.Format(Constants.MESSAGE_SHORT_PASSWORD, Constants.MINIMUM_LENGTH), BreachCount = 0 });
        }

        [TestMethod]
        public void TestShortPassword()
        {
            var apiService = new PasswordCheckerService();
            var result = apiService.CheckPassword("Pass1");
            Assert.AreEqual(result, new PasswordCheckResult() { PasswordStrength = Constants.PasswordStrength.NoComply, Message = string.Format(Constants.MESSAGE_SHORT_PASSWORD, Constants.MINIMUM_LENGTH), BreachCount = 0 });
        }

        [TestMethod]
        public void TestLowerCasePassword()
        {
            var apiService = new PasswordCheckerService();
            var result = apiService.CheckPassword("password");
            Assert.AreEqual(result, new PasswordCheckResult() { PasswordStrength = Constants.PasswordStrength.NoComply, Message = Constants.MESSAGE_NO_CAPITAL_LETTERS, BreachCount = 0 });
        }

        [TestMethod]
        public void TestUpperCasePassword()
        {
            var apiService = new PasswordCheckerService();
            var result = apiService.CheckPassword("PASSWORD");
            Assert.AreEqual(result, new PasswordCheckResult() { PasswordStrength = Constants.PasswordStrength.NoComply, Message = Constants.MESSAGE_NO_SMALL_LETTERS, BreachCount = 0 });
        }

        [TestMethod]
        public void TestUpperLowerCasePassword()
        {
            var apiService = new PasswordCheckerService();
            var result = apiService.CheckPassword("Password");
            Assert.AreEqual(result, new PasswordCheckResult() { PasswordStrength = Constants.PasswordStrength.NoComply, Message = Constants.MESSAGE_NO_NUMBER, BreachCount = 0 });
        }

        [TestMethod]
        public void TestVeryWeakUnbreachedPassword()
        {
            var apiService = new PasswordCheckerService();
            var result = apiService.CheckPassword("psdD23");
            Assert.AreEqual(result, new PasswordCheckResult() { PasswordStrength = Constants.PasswordStrength.VeryWeak, Message = string.Empty, BreachCount = 0 });
        }
        [TestMethod]
        public void TestVeryWeakBreachedPassword()
        {
            var apiService = new PasswordCheckerService();
            var result = apiService.CheckPassword("Pass12");
            Assert.AreEqual(result, new PasswordCheckResult() { PasswordStrength = Constants.PasswordStrength.VeryWeak, Message = string.Empty, BreachCount = 354 });
        }

        [TestMethod]
        public void TestWeakUnbreachedPassword()
        {
            var apiService = new PasswordCheckerService();
            var result = apiService.CheckPassword("pAsS123");
            Assert.AreEqual(result, new PasswordCheckResult() { PasswordStrength = Constants.PasswordStrength.Weak, Message = string.Empty, BreachCount = 0 });
        }
        [TestMethod]
        public void TestWeakBreachedPassword()
        {
            var apiService = new PasswordCheckerService();
            var result = apiService.CheckPassword("Pass123");
            Assert.AreEqual(result, new PasswordCheckResult() { PasswordStrength = Constants.PasswordStrength.Weak, Message = string.Empty, BreachCount = 3981 });
        }

        [TestMethod]
        public void TestMediumUnbreachedPassword()
        {
            var apiService = new PasswordCheckerService();
            var result = apiService.CheckPassword("Pass$12");
            Assert.AreEqual(result, new PasswordCheckResult() { PasswordStrength = Constants.PasswordStrength.Medium, Message = string.Empty, BreachCount = 0 });
        }
        [TestMethod]
        public void TestMediumBreachedPassword()
        {
            var apiService = new PasswordCheckerService();
            var result = apiService.CheckPassword("Pa$$1234");
            Assert.AreEqual(result, new PasswordCheckResult() { PasswordStrength = Constants.PasswordStrength.Medium, Message = string.Empty, BreachCount = 33 });
        }
        [TestMethod]
        public void TestStrongUnbreachedPassword()
        {
            var apiService = new PasswordCheckerService();
            var result = apiService.CheckPassword("Pas$93453");
            Assert.AreEqual(result, new PasswordCheckResult() { PasswordStrength = Constants.PasswordStrength.Strong, Message = string.Empty, BreachCount = 0 });
        }
        [TestMethod]
        public void TestStrongBreachedPassword()
        {
            var apiService = new PasswordCheckerService();
            var result = apiService.CheckPassword("Pa$$w0rd1");
            Assert.AreEqual(result, new PasswordCheckResult() { PasswordStrength = Constants.PasswordStrength.Strong, Message = string.Empty, BreachCount = 327 });
        }
        [TestMethod]
        public void TestNullPassword()
        {
            var apiService = new PasswordCheckerService();
            var result = apiService.CheckPassword(null);
            Assert.AreEqual(result, new PasswordCheckResult() { PasswordStrength = Constants.PasswordStrength.NoComply, Message = string.Format(Constants.MESSAGE_SHORT_PASSWORD, Constants.MINIMUM_LENGTH), BreachCount = 0 });
        }

    }
}
