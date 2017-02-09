using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.WEB.Models
{
    public class DialogViewModel
    {
        public int DialogId { get; set; }

        public string SenderId { get; set; }

        public string RecipientId { get; set; }

        public string UserProfileId { get; set; }

        public string SenderName { get; set; }

        public string File { get; set; }

        public string LastMessage { get; set; }

        public ICollection<MessageViewModel> Messages { get; set; }

    }
}