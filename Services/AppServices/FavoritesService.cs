using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Domain.DTOs.FavoritesDTOs;
using Domain.Entities;
using Domain.Interfaces.AppServicesInterfaces;
using Domain.Interfaces.RepositoryInterfaces;
using Services.Models;

namespace Services.AppServices
{
    public class FavoritesService : IFavoritesService
    {
        private readonly IFavoritesRepository _repository;
        private readonly IMapper _mapper;

        public FavoritesService(IFavoritesRepository favoritesRepository, IMapper mapper)
        {
            _repository = favoritesRepository;
            _mapper = mapper;
        }
        public async Task<FavoritesDTOSimpleResult> Create(FavoritesDTOCreate favorite)
        {
            var model = _mapper.Map<FavoritesModel>(favorite);
            var result = await _repository.InsertAsync(_mapper.Map<FavoritesEntity>(model));
            var favoriteCreated = await _repository.SelectCompleteAsync(result.Id);
            return _mapper.Map<FavoritesDTOSimpleResult>(favoriteCreated);
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<FavoritesDTOSimpleResult> Get(Guid id)
        {
            var result = await _repository.SelectAsync(id);
            return _mapper.Map<FavoritesDTOSimpleResult>(result);
        }

        public async Task<IEnumerable<FavoritesDTOSimpleResult>> GetAll()
        {
            var result = await _repository.SelectAsync();
            return _mapper.Map<IEnumerable<FavoritesDTOSimpleResult>>(result);
        }

        public async Task<FavoritesDTOSimpleResult> GetByUserAndExpert(Guid userId, Guid expertId)
        {
            var result = await _repository.SelectAsync(userId, expertId);
            return _mapper.Map<FavoritesDTOSimpleResult>(result);
        }
    }
}
