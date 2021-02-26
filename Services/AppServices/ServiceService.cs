using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Domain.DTOs.ServiceDTOs;
using Domain.Entities;
using Domain.Interfaces.AppServicesInterfaces;
using Domain.Interfaces.RepositoryInterfaces;
using Services.Models;

namespace Services.AppServices
{
    public class ServiceService : IServiceService
    {
        private readonly IServiceRepository _serviceRepository;
        private readonly IMapper _mapper;

        public ServiceService(IServiceRepository serviceRepository, IMapper mapper)
        {
            _serviceRepository = serviceRepository;
            _mapper = mapper;
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _serviceRepository.DeleteAsync(id);
        }

        public async Task<ServiceDTOSimpleResult> Get(Guid id)
        {
            var result = await _serviceRepository.SelectAsync(id);
            return _mapper.Map<ServiceDTOSimpleResult>(result);
        }

        public async Task<IEnumerable<ServiceDTOSimpleResult>> GetAll()
        {
            var result = await _serviceRepository.SelectAsync();
            return _mapper.Map<IEnumerable<ServiceDTOSimpleResult>>(result);
        }

        public async Task<ServiceDTOSimpleResult> GetByCode(string codigo)
        {
            var result = await _serviceRepository.SelectAsync(codigo);
            return _mapper.Map<ServiceDTOSimpleResult>(result);
        }

        public async Task<ServiceDTOCompleteResult> GetCompleteById(Guid id)
        {
            var result = await _serviceRepository.SelectComplete(id);
            return _mapper.Map<ServiceDTOCompleteResult>(result);
        }

        public async Task<ServiceDTOSimpleResult> Post(ServiceDTOCreate service)
        {
            var model = _mapper.Map<ServiceModel>(service);
            var result = await _serviceRepository.InsertAsync(_mapper.Map<ServiceEntity>(model));
            return _mapper.Map<ServiceDTOSimpleResult>(result);
        }
    }
}
