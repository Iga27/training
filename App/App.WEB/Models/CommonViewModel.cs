using App.BLL.BusinessModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.WEB.Models
{
    public class CommonViewModel
    {
        public IEnumerable<PostViewModel> Posts { get; set; }
        public PageInfo PageInfo { get; set; }
        public string CurrentCategory { get; set; }

        public List<string> CategoriesList { get; set; }

         public CommonViewModel()
        {
            CategoriesList = new List<string>()
            {
                "все",
                "курьерские услуги",
                "ремонт",
                "другое",
                "доставка"
            };
        }
        
    }
}