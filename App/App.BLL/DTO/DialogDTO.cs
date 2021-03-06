﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BLL.DTO
{
   public  class DialogDTO
    {
        public int DialogId { get; set; }

        public string SenderId { get; set; }

        public string RecipientId { get; set; }

        public ICollection<MessageDTO> Messages { get; set; } 

       public DialogDTO()
        {
            Messages = new List<MessageDTO>();
        }
    }
}
