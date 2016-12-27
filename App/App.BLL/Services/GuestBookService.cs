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
    public class GuestBookService : IGuestBookService
    {  
        IUnitOfWork DB { get; set; }
        public GuestBookService(IUnitOfWork uow)
        {
            DB = uow;
        }
       public void AddMessage(GuestBookMessageDTO gbmDto)
        {
            GuestBookMessage message = new GuestBookMessage
            {
                GuestName = gbmDto.GuestName,
                WhenAdded = gbmDto.WhenAdded,
                Message = gbmDto.Message
            };
            DB.GuestBook.Add(message);
            DB.Save();
        }

       public IEnumerable<GuestBookMessageDTO> GetMessages()
       {
           Mapper.Initialize(cfg => cfg.CreateMap<GuestBookMessage, GuestBookMessageDTO>());
           return Mapper.Map<IEnumerable<GuestBookMessage>, List<GuestBookMessageDTO>>(DB.GuestBook.GetAll());
       }
 
    }
}
