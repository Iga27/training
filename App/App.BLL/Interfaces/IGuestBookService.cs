using App.BLL.DTO;
using System;
using System.Collections.Generic;
 
 

namespace App.BLL.Interfaces
{
    public interface IGuestBookService
    {
        void AddMessage(GuestBookMessageDTO gbmDto);

        IEnumerable<GuestBookMessageDTO> GetMessages();

    }
}
