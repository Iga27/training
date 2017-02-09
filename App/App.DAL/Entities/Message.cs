using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DAL.Entities
{
    public class Message
    {
        public int MessageId { get; set; }
        public string SenderId { get; set; }

        public string RecipientId { get; set; }
        public string Text { get; set; }

        public DateTime ? Time { get; set; }

        public Dialog Dialog { get; set; }

        public int DialogId { get; set; }
    }
}
