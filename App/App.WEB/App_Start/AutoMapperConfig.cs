using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using App.WEB.Models;
using App.BLL.DTO;

namespace App.WEB.App_Start
{
    public static class AutoMapperConfig
    {
        public static MapperConfiguration MapperConfiguration;

        public static void RegisterMappings()
        {
            MapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PostDTO, PostViewModel>().ReverseMap();
            });
        }
    }
}