using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using App.BLL.Interfaces;
using System.Threading.Tasks;
using App.WEB.Models;
using App.BLL.DTO;
using System.Security.Claims;
using App.BLL.Infrastructure;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;

namespace App.WEB.Controllers
{
    public class AccountController : Controller
    {
         IUserService userService;

        public AccountController(IUserService service)
        {
            userService = service;
        }
        private IAuthenticationManager AuthenticationManager //нужен
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication; //////
            }
        }
        private IUserService UserService
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<IUserService>();
            }
        }
 
        public ActionResult Login()
        {
            return View();
        }

         [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model)
        {
             await SetInitialDataAsync();  //возможно потом удалить
            if (ModelState.IsValid)
            {
                UserDTO userDto = new UserDTO { Email=model.Email, Password = model.Password};
                ClaimsIdentity claim = await userService.Authenticate(userDto);
                if (claim == null)
                {
                    ModelState.AddModelError("", "Неверный логин или пароль.");
                }
                else
                {
                    AuthenticationManager.SignOut();
                    AuthenticationManager.SignIn(new AuthenticationProperties
                    {
                        IsPersistent = true
                    }, claim);
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(model);
        }
 
        public ActionResult Logout()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Index", "Home");
        }
 
        public ActionResult Register()
        {
            return View();
        }
 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            await SetInitialDataAsync();
            if (ModelState.IsValid)
            {
                UserDTO userDto = new UserDTO
                {
                    Email = model.Email,
                    Password = model.Password,
                    Role = "user"
                };
                OperationInfo operationInfo = await userService.Create(userDto);
                if (operationInfo.Succedeed)
                {
                    ClaimsIdentity claim = await userService.Authenticate(userDto);
                    AuthenticationManager.SignOut();
                    AuthenticationManager.SignIn(new AuthenticationProperties
                    {
                        IsPersistent = true
                    }, claim);
                    // return RedirectToAction("Index", "Home"); ////return View
                   // return View("~/Views/Home/Index.cshtml");
                    return RedirectToAction("Index", "Home");
                }
                else
                    ModelState.AddModelError(operationInfo.Property, operationInfo.Message);
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Index", "Home");
        }
        private async Task SetInitialDataAsync()
        {
            await userService.SetInitialData(new UserDTO
            {
                Email = "somemail@mail.ru",
                Password = "ad46D_ewr3",
                Name = "Семен Семенович Горбунков",
                Role="admin",
            }, new List<string> { "user", "admin" });
        }
    }
}