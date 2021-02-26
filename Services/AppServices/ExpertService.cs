using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Domain.DTOs.ExpertDTOs;
using Domain.Entities;
using Domain.Interfaces.AppServicesInterfaces;
using Domain.Interfaces.RepositoryInterfaces;
using Services.Models;

namespace Services.AppServices
{
    public class ExpertService : IExpertService
    {
        private readonly IExpertRepository _expertRepository;
        private readonly IPhotoRepository _photoRepository;
        private readonly IMapper _mapper;

        public ExpertService(IExpertRepository expertRepository, IPhotoRepository photoRepository, IMapper mapper)
        {
            _expertRepository = expertRepository;
            _photoRepository = photoRepository;
            _mapper = mapper;
        }

        public async Task<ExpertDTOSimpleResult> CreateExpert(ExpertDTOCreate expert)
        {
            var model = _mapper.Map<ExpertModel>(expert);
            model.Role = "User";
            model.Password = BCrypt.Net.BCrypt.HashPassword(model.Password);
            model.Stars = 0;
            var result = await _expertRepository.InsertAsync(_mapper.Map<ExpertEntity>(model));
            return _mapper.Map<ExpertDTOSimpleResult>(result);
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _expertRepository.DeleteAsync(id);
        }

        public async Task<ExpertDTOSimpleResult> Get(Guid id)
        {
            var result = await _expertRepository.SelectAsync(id);
            return _mapper.Map<ExpertDTOSimpleResult>(result);
        }

        public async Task<IEnumerable<ExpertDTOSimpleResult>> GetAll()
        {
            var result = await _expertRepository.SelectAsync();
            return _mapper.Map<IEnumerable<ExpertDTOSimpleResult>>(result);
        }

        public async Task<IEnumerable<ExpertDTOSimpleResult>> GetByLocation(string location)
        {
            var result = await _expertRepository.SelectAsync(location);
            return _mapper.Map<IEnumerable<ExpertDTOSimpleResult>>(result);
        }

        public async Task<ExpertDTOCompleteResult> GetComplete(Guid id)
        {
            var result = await _expertRepository.SelectCompleteAsync(id);
            return _mapper.Map<ExpertDTOCompleteResult>(result);
        }

        public async Task<ExpertDTOSimpleResult> UpdateExpert(ExpertDTOUpdate expert)
        {
            var expertModel = _mapper.Map<ExpertModel>(expert);
            expertModel.Password = expertModel.Password != null ? BCrypt.Net.BCrypt.HashPassword(expertModel.Password) : null;
            var result = await _expertRepository.UpdateAsync(_mapper.Map<ExpertEntity>(expertModel));
            return _mapper.Map<ExpertDTOSimpleResult>(result);
        }
    }
}
