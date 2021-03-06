using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces.RepositoryInterfaces
{
    public interface IFavoritesRepository : IRepository<FavoritesEntity>
    {
        Task<FavoritesEntity> SelectAsync(Guid userId, Guid expertId);
        Task<FavoritesEntity> SelectCompleteAsync(Guid id);
    }
}
