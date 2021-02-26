using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.DTOs.UserDTOs;

namespace Domain.Interfaces.AppServicesInterfaces
{
    public interface ISignService
    {
        Task<object> SignInService(UserDTOLogin email);

        Task<object> SignUpService(UserDTOCreate user);
    }
}
