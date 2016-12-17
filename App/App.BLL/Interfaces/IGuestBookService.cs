using App.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BLL.Interfaces
{
    public interface IGuestBookService
    {
        void AddMessage(GuestBookMessageDTO gbmDto);

        IEnumerable<GuestBookMessageDTO> GetMessages();

        void Dispose();
    }
}
