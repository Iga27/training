using System;
using System.Collections.Generic;
using App.BLL.Interfaces;
using App.DAL.Entities;
using App.DAL.Interfaces;
using App.BLL.DTO;
using App.BLL.Infrastructure;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using System.Security.Claims;
using AutoMapper;
 

namespace App.BLL.Services
{
    public class UserService : IUserService
    {
        IUnitOfWork DB { get; set; }

        public UserService(IUnitOfWork uow)
        {
            DB = uow;
        }

        public async Task<OperationInfo> Create(UserDTO userDto)
        {
            User user = await DB.Users.FindByEmailAsync(userDto.Email);
            if (user == null)
            {
                user = new User { Email = userDto.Email, UserName = userDto.Email };  
                var result = await DB.Users.CreateAsync(user, userDto.Password);
              

                // добавляем роль
                if (result.Succeeded)
               result= await DB.Users.AddToRoleAsync(user.Id, userDto.Role);
      
                UserProfile userProfile = new UserProfile { Id = user.Id, Info = userDto.Info, Name = userDto.Name,Age=userDto.Age };

                if (result.Succeeded)
                DB.UserProfiles.Create(userProfile);
                await DB.SaveAsync();
                return new OperationInfo(true, "Регистрация успешно пройдена", "");
            }
            else
            {
                return new OperationInfo(false, "Пользователь с таким логином уже существует", "Email");
            }
        }

        public async Task<ClaimsIdentity> Authenticate(UserDTO userDto)
        {
            ClaimsIdentity claim = null;
            // находим пользователя
               User user = await DB.Users.FindAsync(userDto.Email, userDto.Password);   
             
            if (user != null)
                claim = await DB.Users.CreateIdentityAsync(user,
                                            DefaultAuthenticationTypes.ApplicationCookie);
            return claim;
        }

 
        // начальная инициализация бд
        public async Task SetInitialData(UserDTO adminDto, List<string> roles)
        {
            foreach (string roleName in roles)
            {
                var role = await DB.Roles.FindByNameAsync(roleName);
                if (role == null)
                {
                    role = new  Role { Name = roleName };
                    await DB.Roles.CreateAsync(role);
                }
            }
            await Create(adminDto);
        }

        public void Dispose()
        {
            DB.Dispose();
        }
    }
}
