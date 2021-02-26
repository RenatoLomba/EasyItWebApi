using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Domain.DTOs.TestimonialDTOs;
using Domain.Entities;
using Domain.Interfaces.AppServicesInterfaces;
using Domain.Interfaces.RepositoryInterfaces;
using Services.Models;

namespace Services.AppServices
{
    public class TestimonialService : ITestimonialService
    {
        private readonly ITestimonialRepository _repository;
        private readonly IMapper _mapper;

        public TestimonialService(ITestimonialRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<TestimonialDTOSimpleResult> Create(TestimonialDTOCreate testimonial)
        {
            var model = _mapper.Map<TestimonialModel>(testimonial);
            var result = await _repository.InsertAsync(_mapper.Map<TestimonialEntity>(model));
            return _mapper.Map<TestimonialDTOSimpleResult>(result);
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<TestimonialDTOSimpleResult> Get(Guid id)
        {
            var result = await _repository.SelectAsync(id);
            return _mapper.Map<TestimonialDTOSimpleResult>(result);
        }

        public async Task<IEnumerable<TestimonialDTOSimpleResult>> GetAll()
        {
            var result = await _repository.SelectAsync();
            return _mapper.Map<IEnumerable<TestimonialDTOSimpleResult>>(result);
        }

        public async Task<TestimonialDTOCompleteResult> GetComplete(Guid id)
        {
            var result = await _repository.SelectCompleteAsync(id);
            return _mapper.Map<TestimonialDTOCompleteResult>(result);
        }
    }
}
