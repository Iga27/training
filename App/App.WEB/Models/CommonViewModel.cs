using App.BLL.BusinessModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.WEB.Models
{
    public class CommonViewModel
    {
        public IEnumerable<PostViewModel> Posts { get; set; }
        public PageInfo PageInfo { get; set; }
        public string CurrentCategory { get; set; }
    }
}