using System;


namespace App.BLL.DTO
{
    public class PostDTO
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public int Price { get; set; }
        public string UserId { get; set; }  

        public DateTime ? Date { get; set; }
    }
}
