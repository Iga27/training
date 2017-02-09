using App.BLL.DTO;
using App.BLL.Interfaces;
using App.WEB.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace App.WEB.Controllers
{
    [Authorize]
    public class MessagesController : Controller
    {
        
        IMessageService messageService;
        IUserProfileService userProfileService;
        public MessagesController(IMessageService msgService,IUserProfileService usrProfileService)
        {
            messageService = msgService;
            userProfileService=usrProfileService;
        }


        private IEnumerable<DialogViewModel> Mapp(IEnumerable<DialogDTO> dialogsdto)
        {
            //DialogDTO->DialogViewModel

            var dialogsViewModel = new List<DialogViewModel>();
            foreach (var dialogdto in dialogsdto)
            {


                var dialogViewModel = new DialogViewModel
                {

                    DialogId = dialogdto.DialogId,
                    RecipientId = dialogdto.RecipientId,
                    SenderId = dialogdto.SenderId,
                };
                var messagesviewmodel = new List<MessageViewModel>();
                foreach (var messagedto in dialogdto.Messages)
                {
                    var messageViewModel = new MessageViewModel
                    {
                        MessageId = messagedto.MessageId,
                        RecipientId = messagedto.RecipientId,
                        SenderId = messagedto.SenderId,
                        DialogId = messagedto.DialogId,
                        Text = messagedto.Text,
                        Time=messagedto.Time
                    };
                    messagesviewmodel.Add(messageViewModel);

                }
                dialogViewModel.Messages = messagesviewmodel;
                dialogsViewModel.Add(dialogViewModel);
            }
            return dialogsViewModel;
        }

        public ActionResult Dialogs()  
        {
            
            var dialogs = Mapp(messageService.GetDialogs(User.Identity.GetUserId()));
           

            foreach(var dialog in dialogs)
            {
                 string id = (dialog.SenderId != User.Identity.GetUserId()) ? dialog.SenderId : dialog.RecipientId;
                var userInfo = userProfileService.GetUserProfile(id);  
                dialog.File=userInfo.File;
                dialog.SenderName=userInfo.Name;
            }

            return View(dialogs); 
        }  
          

        public ActionResult Messages(int dialogId = 0)
        {

            var dialogs = Mapp(messageService.GetDialogs(User.Identity.GetUserId()));
            

            foreach(var dialog in dialogs)
            {
                if(dialog.DialogId==dialogId)
                {
                    foreach(var msg in dialog.Messages)
                    {
                        var userInfo = userProfileService.GetUserProfile(msg.SenderId);
                        msg.SenderName = userInfo.Name;
                        msg.File = userInfo.File;
                    }
                    return View(dialog.Messages.OrderByDescending(m=>m.Time));
                }
            }
            

            return View();
        } 
    }
}