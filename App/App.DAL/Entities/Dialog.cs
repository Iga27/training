using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DAL.Entities
{
    public class Dialog
    {
        public int DialogId { get; set; }

        public string SenderId { get; set; }

        public string RecipientId { get; set; }

        public virtual ICollection<Message> Messages { get; set; }

        public Dialog()
        {
            Messages = new List<Message>();
        }
    }
}
