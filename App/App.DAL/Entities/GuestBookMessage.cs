using System;

namespace App.DAL.Entities
{
    public class GuestBookMessage
    {
        public int Id { get; set; }
        public string GuestName { get; set; }
        public string Message { get; set; }
        public DateTime WhenAdded { get; set; }
    }
}
