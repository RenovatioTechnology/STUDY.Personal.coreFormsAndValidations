using coreFormsAndValidations.Models;
using Microsoft.AspNetCore.Mvc;

namespace coreFormsAndValidations.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult WeeklyLogin()
        {
            return View();
        }
        // Post Method
        [HttpPost]
        // weekly type,whatever property you are associating here,in our case from the "WeeklyLogin View" the two string values will be taken here. One is the username and one is the password. 
        public IActionResult Loginpost(string username,string password)
        {
            ViewBag.Username = username;    
            ViewBag.Password = password;    
            return View();
        }

        // LoginViewModel
        public IActionResult StrongSecureLogin()
        {
            return View();
        }
        [HttpPost]
        public IActionResult LoginSuccess(LoginViewModel login) 
        {
            ViewBag.Username = login.Username;
            ViewBag.Password = login.Password; 
            return View();
        }

    }
}
