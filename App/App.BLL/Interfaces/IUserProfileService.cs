using App.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BLL.Interfaces
{
    public interface IUserProfileService
    {
        UserProfileDTO GetUserProfile(string id);

       void EditProfile(UserProfileDTO userProfileDto);

       //void CreateUserProfile(UserProfileDTO userProfileDto);  //ЭТО ДОБАВИЛ
    }
}
