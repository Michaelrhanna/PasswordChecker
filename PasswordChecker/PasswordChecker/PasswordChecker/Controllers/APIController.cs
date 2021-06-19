using Microsoft.AspNetCore.Mvc;
using PasswordChecker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PasswordChecker.Controllers
{
    [ApiController]
    public class APIController : Controller
    {
        private IPasswordCheckerService _PasswordCheckerService;
        public APIController(IPasswordCheckerService passwordCheckerService)
        {
            _PasswordCheckerService = passwordCheckerService;
        }

        [Route ("/")]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [Route("/CheckPassword")]
        [HttpGet]
        public PasswordCheckResult CheckPassword(string password)
        {
            PasswordCheckResult passwordCheckResult = new PasswordCheckResult();

            try
            {
                passwordCheckResult = _PasswordCheckerService.CheckPassword(password); 
            }
            catch (Exception ex)
            { 
            }
            return passwordCheckResult;

        }
    }
}
