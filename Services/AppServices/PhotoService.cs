using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Domain.DTOs.PhotoDTOs;
using Domain.Entities;
using Domain.Interfaces.AppServicesInterfaces;
using Domain.Interfaces.RepositoryInterfaces;
using Services.Models;

namespace Services.AppServices
{
    public class PhotoService : IPhotoService
    {
        private readonly IPhotoRepository _repository;
        private readonly IMapper _mapper;

        public PhotoService(IPhotoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PhotoDTOSimpleResult> Create(PhotoDTOCreate photo)
        {
            var model = _mapper.Map<PhotoModel>(photo);
            var result = await _repository.InsertAsync(_mapper.Map<PhotoEntity>(model));
            return _mapper.Map<PhotoDTOSimpleResult>(result);
        }

        public async Task<bool> Delete(Guid id)
        {
            var result = await _repository.DeleteAsync(id);
            return result;
        }

        public async Task<PhotoDTOSimpleResult> Get(Guid id)
        {
            var result = await _repository.SelectAsync(id);
            return _mapper.Map<PhotoDTOSimpleResult>(result);
        }

        public async Task<IEnumerable<PhotoDTOSimpleResult>> GetAll()
        {
            var result = await _repository.SelectAsync();
            return _mapper.Map<IEnumerable<PhotoDTOSimpleResult>>(result);
        }
    }
}
