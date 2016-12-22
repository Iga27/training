using App.BLL.DTO;
using System;
 

namespace App.BLL.Interfaces
{
    public interface IUserProfileService
    {
        UserProfileDTO GetUserProfile(string id);

       void EditProfile(UserProfileDTO userProfileDto);

       void Dispose();
    }
}
