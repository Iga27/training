using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using App.BLL.DTO;
using App.BLL.Infrastructure;

namespace App.BLL.Interfaces
{
    public interface IUserService : IDisposable
    {
        Task<OperationInfo> Create(UserDTO userDto);
        Task<ClaimsIdentity> Authenticate(UserDTO userDto);
        Task SetInitialData(UserDTO adminDto, List<string> roles);
    }
}
