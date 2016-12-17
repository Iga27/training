using App.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using App.WEB.Models;
using App.BLL.DTO;
using AutoMapper;
using App.BLL.Infrastructure;
using System.Net;
using App.WEB.App_Start;

namespace App.WEB.Controllers
{
    public class ProfileController : Controller
    {
          IUserProfileService userProfileService;
          IUserService userService;

        public ProfileController(IUserProfileService profileService,IUserService usrService)
        {
            userProfileService = profileService;
            userService = usrService;
        }

        [HttpGet]
         public ViewResult UserProfile(string id)
        {
            //var currentuserid = User.Identity.GetUserId();
           
           // var userdetail = userProfileService.GetUser(id);

            var profile = userProfileService.GetUserProfile(id);
           // profile.Id = id; //это добавил
            Mapper.Initialize(m => m.CreateMap<UserProfileDTO, UserProfileViewModel>());
            var userProfile = Mapper.Map<UserProfileDTO, UserProfileViewModel>(profile);            
            return View(userProfile);
        }

        [HttpGet]
        public ActionResult EditProfile(string id)  
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IMapper Mapper = AutoMapperConfig.MapperConfiguration.CreateMapper();
            UserProfileViewModel profileView = Mapper.Map<UserProfileDTO, UserProfileViewModel>(userProfileService.GetUserProfile(id));

            if (profileView == null)
            {
                return HttpNotFound();
            }
            return View(profileView);

        }
        [HttpPost]
        public ActionResult EditProfile(UserProfileViewModel editedProfile, HttpPostedFileBase file)
        {
            try
            {

                if (file != null)
                {
                    DateTime time = DateTime.Now;
                    string fileName = System.IO.Path.GetFileName(file.FileName);
                    string path = "~/Images/" +time.ToString("H:mm:ss").Replace(":", "_")+ fileName; 
                    file.SaveAs(Server.MapPath(path));
                    editedProfile.File = path;
                }
                //editedProfile.Id = userService.; //это добавил
                Mapper.Initialize(m => m.CreateMap<UserProfileViewModel, UserProfileDTO>());
                var userProfileDto = Mapper.Map<UserProfileViewModel, UserProfileDTO>(editedProfile);
                userProfileService.EditProfile(userProfileDto);
                ViewBag.UserProfileId = editedProfile.Id;
                return RedirectToAction("Index","Post");  //View  //возвращать представление откуда и пришел.и возвращать к профилю
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }
            return View(editedProfile);          
        }
    }
}