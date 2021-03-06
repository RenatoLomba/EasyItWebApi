using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Data.Context;
using Domain.Entities;
using Domain.Interfaces.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository
{
    public class FavoritesRepository : BaseRepository<FavoritesEntity>, IFavoritesRepository
    {
        private readonly DbSet<FavoritesEntity> _dataSet;

        public FavoritesRepository(MyContext context) : base(context)
        {
            _dataSet = context.Set<FavoritesEntity>();
        }
        public async Task<FavoritesEntity> SelectAsync(Guid userId, Guid expertId)
        {
            try
            {
                var result = await _dataSet.FirstOrDefaultAsync(f => f.UserId.Equals(userId) && f.ExpertId.Equals(expertId));
                return result;
            } catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<FavoritesEntity> SelectCompleteAsync(Guid id)
        {
            try
            {
                var result = await _dataSet.Include(f => f.Expert).FirstOrDefaultAsync(f => f.Id.Equals(id));
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
