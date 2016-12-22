using System;


namespace App.BLL.DTO
{
    public class GuestBookMessageDTO
    {
        public int Id { get; set; }
        public string GuestName { get; set; }
        public string Message { get; set; }
        public DateTime WhenAdded { get; set; }
    }
}
