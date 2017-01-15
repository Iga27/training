using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using App.BLL.DTO;
using App.WEB.Models;
using AutoMapper;
using App.BLL.Interfaces;
using System.Web.Http.Controllers;

namespace App.WEB.Controllers
{
    
    public class GuestBookApiController : ApiController
    {
        IGuestBookService guestBookService;

        public GuestBookApiController(IGuestBookService _guestBookService)
        {
            guestBookService = _guestBookService;
        }

        public IEnumerable<GuestBookMessageViewModel> GetAllMessages()
        {
            var messagesDto = guestBookService.GetMessages();
            Mapper.Initialize(m => m.CreateMap<GuestBookMessageDTO, GuestBookMessageViewModel>());
            return  Mapper.Map<IEnumerable<GuestBookMessageDTO>, IEnumerable<GuestBookMessageViewModel>>(messagesDto);            
        }

        [HttpPost]
        public HttpResponseMessage AddMessage([FromBody]GuestBookMessageViewModel guestViewModel)
        {
             
            Mapper.Initialize(m => m.CreateMap<GuestBookMessageViewModel, GuestBookMessageDTO>());
            var guestBookDto = Mapper.Map<GuestBookMessageViewModel, GuestBookMessageDTO>(guestViewModel);

            guestBookDto.WhenAdded =DateTime.Now;
            guestBookService.AddMessage(guestBookDto);

            return new HttpResponseMessage(HttpStatusCode.Created);          
        }

        protected override void Dispose(bool disposing)
        {
            guestBookService.Dispose();
            base.Dispose(disposing);
        }
    }
}
