using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.DTOs.UserDTOs;

namespace Domain.Interfaces.AppServicesInterfaces
{
    public interface ISignService
    {
        Task<object> SignInService(UserDTOLogin email, bool authenticated);

        Task<object> SignUpService(UserDTOCreate user);
    }
}
