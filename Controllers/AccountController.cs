using coreFormsAndValidations.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System.ComponentModel;
using System;
using Humanizer;
using System.IO;

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
            //  ViewBag.Username = login.Username;
            //   ViewBag.Password = login.Password; 


            //   expecting the parameter into the post you can directly create the object of your strong secure model and access the values, check with the if condition.
            //   If login.username is not equals to null and password is also not equals to null, then come inside it and check the logic.
            //   Teh post you like to check if the fields are not empty if login.username is equals admin and login.password also admin.
            //   ViewBag.Message property, you are successfully logged in.
            if (login.Username !=null && login.Password != null)
            {
                if(login.Username.Equals("admin")&& login.Password.Equals("admin"))
                {
                    ViewBag.Message = "You've successfully logged in.";
                    return View();
                }

            }
            // Before returning to the view  you can directly assign one message for all the else otherwise condition invalid credentials.
            ViewBag.Message = "Invalid Credentials.";
            return View();
        }

        //Model Binding
        public IActionResult UserDetail()
        {
            var user = new LoginViewModel()
            {
                Username = "JNah",
                Password = "12356"
            };
            return View(user);

        }
        public IActionResult UserList()
        {
            var users = new List<LoginViewModel>()
            {
                new LoginViewModel(){ Username = "JNah", Password = "12356" },
                new LoginViewModel(){ Username = "Mike", Password = "12356" },
                new LoginViewModel(){ Username = "King", Password = "12356"}
        };
            return View(users);   

        }

        //Forms Validations - Server Side and Client Side
        // validating Account.cs with the help of the action method below
        public IActionResult GetAccount()
        {
            // Remember to Add a Razor View w/tamplate→Create→Model class→Account for the View
            return View();

        }

        [HttpPost] 
        public IActionResult PostAccount(Account account)
        {
            if (ModelState.IsValid)
            {
                // Dont forget we will require a view for this success
                return View("Success");
            }
            // Otherwise return to GetAccount View
            return RedirectToAction("GetAccount");
        }
    }
}
