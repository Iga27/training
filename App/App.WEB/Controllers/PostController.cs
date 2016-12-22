using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using App.BLL.Interfaces;
using App.BLL.DTO;
using App.WEB.Models;
using AutoMapper;
using App.BLL.Infrastructure;
using System.Data.Entity.Validation;
using System.Diagnostics;
using Microsoft.AspNet.Identity;
using System.Net;
using App.WEB.App_Start;
using App.BLL.BusinessModels;

namespace App.WEB.Controllers
{
    public class PostController : Controller
    {
        IPostService postService;
        IUserService userService;

       public int pageSize = 5;

        public PostController(IPostService pstService,IUserService usrService)
        {
            postService = pstService;
            userService = usrService;
        }

         
        public ActionResult Index(string category,int page=1)
        {
            PageInfo pageInfo = new PageInfo
            {
                PageNumber = page,
                PageSize = pageSize,
                TotalItems = category == "все" ?
           postService.Count() : (category == null ? postService.Count() :
           postService.GetPosts().Where(m => m.Category == category).Count())
           
            };


            IEnumerable<PostDTO> postDTOs = postService.GetPostsByCategory(category,page);
            Mapper.Initialize(m => m.CreateMap<PostDTO, PostViewModel>());
            var posts = Mapper.Map<IEnumerable<PostDTO>, List<PostViewModel>>(postDTOs);

            var cvm = new CommonViewModel
            {
                PageInfo = pageInfo, Posts = posts, CurrentCategory = category
            };
            

            if (Request.IsAjaxRequest())
                return PartialView("IndexPartial",cvm);
            
            return View(cvm);
        }

        [Authorize]  
        public ActionResult WritePost()  
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }
                return View();
        }

        [HttpPost]
        public ActionResult WritePost(PostViewModel post)
        {
            try
            {
               
                Mapper.Initialize(m => m.CreateMap<PostViewModel, PostDTO>());
                var postDto = Mapper.Map<PostViewModel, PostDTO>(post);

                postDto.UserId = User.Identity.GetUserId();  
                postDto.Date = DateTime.Now;  
                postService.CreatePost(postDto);
                return RedirectToAction("Index");  
            }
                
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }
            return View(post);
        }


        //Handle

        //role==admin
        [Authorize(Roles = "admin")]
        public ActionResult Handle()
        {
             
            IEnumerable<PostDTO> postDTOs = postService.GetPosts();
            Mapper.Initialize(m => m.CreateMap<PostDTO, PostViewModel>());
            var posts = Mapper.Map<IEnumerable<PostDTO>, List<PostViewModel>>(postDTOs);

            if (Request.IsAjaxRequest())  
                return PartialView("HandlePartial", posts);
            return View(posts);
        }
       
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IMapper Mapper = AutoMapperConfig.MapperConfiguration.CreateMapper();
            PostViewModel postView = Mapper.Map<PostDTO, PostViewModel>(postService.GetPost((int)id));
             
            if (postView == null)
            {
                return HttpNotFound();
            }

            return View(postView);
        }

        [HttpPost]
        public ActionResult Edit(PostViewModel postView) 
        {
            try
            {
                Mapper.Initialize(m => m.CreateMap<PostViewModel, PostDTO>());
                var postDto = Mapper.Map<PostViewModel, PostDTO>(postView);
                postDto.Date = DateTime.Now;  
                postService.EditPost(postDto);
                return RedirectToAction("Handle"); //View
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }
            return View(postView);           
        }
       
        public ActionResult Delete(int? id)  
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            postService.DeletePost((int)id);

            return RedirectToAction("Handle");  
        }

        protected override void Dispose(bool disposing) 
        {
            postService.Dispose();
            base.Dispose(disposing);
        }

        
    }
}