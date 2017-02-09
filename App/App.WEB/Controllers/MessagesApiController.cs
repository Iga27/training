using App.BLL.DTO;
using App.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using App.WEB.Hubs;

namespace App.WEB.Controllers
{
    public class MessagesApiController : ApiController
    {
        IMessageService messageService;
        IUserProfileService userProfileService;

        public MessagesApiController(IMessageService msg, IUserProfileService usrProfileService)
        {
            messageService = msg;
            userProfileService = usrProfileService;
        }

        private DialogDTO ReturnOrAddDialog(string SenderId,string RecipientId)
        {

            var dialogDto = messageService.GetDialogs(User.Identity.GetUserId()).Where(m => m.RecipientId == RecipientId && m.SenderId == SenderId ||     
                m.SenderId == RecipientId && m.RecipientId == SenderId).FirstOrDefault();

            if (dialogDto == null)
            {
                dialogDto = new DialogDTO
                {
                    RecipientId = RecipientId,
                    SenderId = SenderId,
                };
               int dialogId= messageService.CreateDialog(dialogDto);
               dialogDto.DialogId = dialogId;
            }
            
            return dialogDto;
        }

        [HttpPost]
        public HttpResponseMessage AddMessage([FromBody]MessageDTO messageDto)  
        {
            var dialog = ReturnOrAddDialog(messageDto.SenderId, messageDto.RecipientId);
            messageDto.DialogId = dialog.DialogId;
            //dialog.Messages.Add(messageDto);

            var userInfo = userProfileService.GetUserProfile(messageDto.SenderId);
            messageDto.Time = DateTime.Now;

            messageService.AddMessage(messageDto);

            NotifyAddedMessage(messageDto.SenderId, messageDto.RecipientId, messageDto.Text,userInfo.Name);
            return new HttpResponseMessage(HttpStatusCode.Created);
        }


        private void NotifyAddedMessage(string SenderId,string RecipientId,string text,string name)
        {
            var hub = Microsoft.AspNet.SignalR.GlobalHost.ConnectionManager.GetHubContext<MessagesHub>();


            hub.Clients.All.addedNewMessage(SenderId, RecipientId, text,name);
        }
         
    }
}
