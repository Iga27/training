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

namespace App.Web.Controllers
{
    public class HomeController : Controller
    {
        IGuestBookService guestBookService;

        public HomeController(IGuestBookService _guestBookService)
        {
            guestBookService = _guestBookService;
        }
        public ActionResult Index()
        {
           /* var messagesDto = guestBookService.GetMessages();
            Mapper.Initialize(m => m.CreateMap<GuestBookMessageDTO, GuestBookMessageViewModel>());
            var messages = Mapper.Map<IEnumerable<GuestBookMessageDTO>, List<GuestBookMessageViewModel>>(messagesDto);
            if (Request.IsAjaxRequest())
                return PartialView("IndexPartial", messages);
            return View("Index",messages);*/
            return View("Index");
        }

        [HttpPost]
        public ActionResult AddMessage(GuestBookMessageViewModel guestViewModel)
        {
            try
            {

                Mapper.Initialize(m => m.CreateMap<GuestBookMessageViewModel, GuestBookMessageDTO>());
                var guestBookDto = Mapper.Map<GuestBookMessageViewModel, GuestBookMessageDTO>(guestViewModel);

                guestBookDto.WhenAdded = DateTime.Now;
                guestBookService.AddMessage(guestBookDto);
                return RedirectToAction("GuestBook");
            }

            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }
            return View(guestViewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult GuestBook()
        {
            var messagesDto = guestBookService.GetMessages();
            Mapper.Initialize(m => m.CreateMap<GuestBookMessageDTO, GuestBookMessageViewModel>());
            var messages = Mapper.Map<IEnumerable<GuestBookMessageDTO>, List<GuestBookMessageViewModel>>(messagesDto);
            if (Request.IsAjaxRequest())
                return PartialView("GuestBookPartial", messages);
            return View("GuestBook", messages);
        }
    }
}