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
    // [Authorize]    //и как-то делать редирект на страницу со входом
    public class PostController : Controller
    {
       readonly IPostService postService;
       readonly  IUserService userService;

       public int pageSize = 3;

        public PostController(IPostService pstService,IUserService usrService)
        {
            postService = pstService;
            userService = usrService;
        }
        public ActionResult Index(string category,int page=1)
        {
            /*if (!String.IsNullOrEmpty(category) && category.GetType() != typeof(string)) //делать проверку,параметр может быть int или другого типа
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }*/

            PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = postService.Count() };
                //=category==null?
            //postService.Count() : postService.GetPosts(page).Where(m=>m.Category==category).Count()};

            IEnumerable<PostDTO> postDTOs = postService.GetPostsByCategory(category,page);
            Mapper.Initialize(m => m.CreateMap<PostDTO, PostViewModel>());
            var posts = Mapper.Map<IEnumerable<PostDTO>, List<PostViewModel>>(postDTOs);

            var cvm = new CommonViewModel { PageInfo = pageInfo, Posts = posts, CurrentCategory = category };
            

            ViewBag.Categories = new SelectList(new List<string>()
            {
                "все",
                "курьерские услуги",
                "ремонт",
                "другое",
                "доставка"
            });
            
            return View(cvm);
        }

        //здесь нужно представление WritePost(httpget) и там выводить ссылку(написать пост)


        public ActionResult WritePost()  
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }
            else
                return View();
                
        }

        [HttpPost]
        public ActionResult WritePost(PostViewModel post)
        {
            try
            {
                Mapper.Initialize(m => m.CreateMap<PostViewModel, PostDTO>());
                var postDto = Mapper.Map<PostViewModel, PostDTO>(post);
                
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
        public ActionResult Handle(int page=1)
        {
            IEnumerable<PostDTO> postDTOs = postService.GetPosts(page);
            Mapper.Initialize(m => m.CreateMap<PostDTO, PostViewModel>());
            var posts = Mapper.Map<IEnumerable<PostDTO>, List<PostViewModel>>(postDTOs);
            return View(posts);
        }
       
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Mapper.Initialize(m => m.CreateMap<PostDTO,PostViewModel>());
            IMapper Mapper = AutoMapperConfig.MapperConfiguration.CreateMapper();
            //var source = new PostDTO();
           // var postView = Mapper.Map<PostDTO, PostViewModel>(source);
            PostViewModel postView = Mapper.Map<PostDTO, PostViewModel>(postService.GetPost((int)id));
             
            if (postView == null)
            {
                return HttpNotFound();
            }
            return View(postView);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Edit(PostViewModel postView) //[Bind(Include = "Id,Description,Price")]
        {
            try
            {
                Mapper.Initialize(m => m.CreateMap<PostViewModel, PostDTO>());
                var postDto = Mapper.Map<PostViewModel, PostDTO>(postView);
                postService.EditPost(postDto);
                return RedirectToAction("Handle");
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

        protected override void Dispose(bool disposing) //возможно(скорее всего) не нужен здесь
        {
            postService.Dispose();
            base.Dispose(disposing);
        }

        
    }
}