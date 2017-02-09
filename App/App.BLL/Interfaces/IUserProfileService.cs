using App.BLL.DTO;
using System;
using System.Collections.Generic;
 

namespace App.BLL.Interfaces
{
    public interface IUserProfileService
    {
        UserProfileDTO GetUserProfile(string id);

       void EditProfile(UserProfileDTO userProfileDto);


      
    }
}
