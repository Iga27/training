using App.BLL.DTO;
using App.BLL.Interfaces;
using App.DAL.Entities;
using App.DAL.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BLL.Services
{
    public class MessageService : IMessageService
    {
        IUnitOfWork DB { get; set; }
        public MessageService(IUnitOfWork uow)
        {
            DB = uow;
        }

        public IEnumerable<DialogDTO> GetDialogs(string currentUser)   
        {
            var dialogsdto = new List<DialogDTO>();
            foreach (var dialog in DB.Messages.GetDialogs(currentUser)) 
            {
                var dialogDto = new DialogDTO
                {
                    DialogId=dialog.DialogId,
                    RecipientId=dialog.RecipientId,
                    SenderId=dialog.SenderId               
                };
                var messagesdto = new List<MessageDTO>();
                foreach (var message in dialog.Messages)
                {
                    var messageDto = new MessageDTO
                    {
                        MessageId=message.MessageId,
                        RecipientId=message.RecipientId,
                        SenderId=message.SenderId,
                        DialogId=message.DialogId,
                        Text=message.Text,
                        Time=message.Time
                    };
                    messagesdto.Add(messageDto);
                }
                dialogDto.Messages = messagesdto;
                dialogsdto.Add(dialogDto);
            }
            return dialogsdto;
        }

        public int CreateDialog(DialogDTO dialogDto)
        {
            Dialog dialog = new Dialog
            {
                RecipientId=dialogDto.RecipientId,
                SenderId=dialogDto.SenderId,
            };


           return  DB.Messages.Create(dialog);
            
        }
        public void Dispose()
        {
            DB.Dispose();
        }

        public void AddMessage(MessageDTO messageDto)
        {

            Message message = new Message
            {
                DialogId=messageDto.DialogId,
                RecipientId=messageDto.RecipientId,
                SenderId=messageDto.SenderId,
                Text=messageDto.Text,
                Time=messageDto.Time

            };

            DB.Messages.AddMessage(message);
            DB.Save();
        }
    }
}
