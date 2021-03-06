using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.DTOs.FavoritesDTOs;

namespace Domain.Interfaces.AppServicesInterfaces
{
    public interface IFavoritesService
    {
        Task<FavoritesDTOSimpleResult> Get(Guid id);
        Task<IEnumerable<FavoritesDTOSimpleResult>> GetAll();
        Task<FavoritesDTOSimpleResult> GetByUserAndExpert(Guid userId, Guid expertId);
        Task<FavoritesDTOSimpleResult> Create(FavoritesDTOCreate favorite);
        Task<bool> Delete(Guid id);
    }
}
