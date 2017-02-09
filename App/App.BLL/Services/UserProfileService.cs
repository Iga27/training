using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using App.BLL.Interfaces;
using App.DAL.Entities;
using App.DAL.Interfaces;
using App.BLL.DTO;
using App.BLL.Infrastructure;
using AutoMapper;
using App.BLL.BusinessModels;

 

namespace App.BLL.Services
{

    public class UserProfileService : IUserProfileService
    {
        IUnitOfWork DB { get; set; }
        public UserProfileService(IUnitOfWork uow)
        {
            DB = uow;
        }

        public UserProfileDTO GetUserProfile(string id)
        {
            if (id == null)
                throw new ValidationException("пользователь не найден", "");

            var userProfile = DB.UserProfiles.Get(id);
            if (userProfile == null)
                throw new ValidationException("пользователь не найден", "");

            Mapper.Initialize(m => m.CreateMap<UserProfile, UserProfileDTO>());
            return Mapper.Map<UserProfile, UserProfileDTO>(userProfile);
        }

        public void EditProfile(UserProfileDTO userProfileDto)
        {  
            Mapper.Initialize(m => m.CreateMap<UserProfileDTO, UserProfile>());
            UserProfile userProfile = Mapper.Map<UserProfileDTO, UserProfile>(userProfileDto);
            DB.UserProfiles.Update(userProfile);
            DB.Save(); 
        }


    }
}
