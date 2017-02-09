using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.WEB.Models
{
    public class MessageViewModel
    {
        public int MessageId { get; set; }
        public string SenderId { get; set; }

        public string RecipientId { get; set; }
        public string Text { get; set; }

        public string SenderName { get; set; }

        public string File { get; set; }

        public DateTime ? Time { get; set; }

        public int DialogId { get; set; }
    }
}