using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.DTOs.UserDTOs;

namespace Domain.Interfaces.AppServicesInterfaces
{
    public interface IUserService
    {
        Task<UserDTOSimpleResult> Get(Guid id);

        Task<UserDTOCompleteResult> GetComplete(Guid id);

        Task<IEnumerable<UserDTOSimpleResult>> GetAll();

        Task<UserDTOSimpleResult> Put(UserDTOUpdate user);

        Task<bool> Delete(Guid id);
    }
}
