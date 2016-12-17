using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace App.WEB.Models
{
    public class GuestBookMessageViewModel
    {
        public int Id { get; set; }
        public string GuestName { get; set; }
        [Required]
        public string Message { get; set; }
        public DateTime WhenAdded { get; set; }
    }
}