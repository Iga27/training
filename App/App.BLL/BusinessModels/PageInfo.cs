using System;


namespace App.BLL.BusinessModels
{
    public class PageInfo
    {
        public int PageNumber { get; set; } // the current page number
        public int PageSize { get; set; } // quantity of objects on the page
        public int TotalItems { get; set; }
        public int TotalPages  
        {
            get { return (int)Math.Ceiling((decimal)TotalItems / PageSize); }
        }
    }
}
