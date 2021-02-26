using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces.RepositoryInterfaces
{
    public interface IUserRepository : IRepository<UserEntity>
    {
        Task<UserEntity> SelectAsync(string email);
        Task<UserEntity> SelectCompleteAsync(Guid id);
        Task<UserEntity> SelectCompleteAsync(string email);
    }
}
