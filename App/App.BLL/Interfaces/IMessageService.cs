using App.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BLL.Interfaces
{
    public interface IMessageService
    {
        IEnumerable<DialogDTO> GetDialogs(string currentUser); 

        int CreateDialog(DialogDTO dialogDto);

        void AddMessage(MessageDTO messageDto);
    }
}
