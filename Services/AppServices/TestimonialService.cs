using System;
using System.Collections.Generic;
using System.Linq;
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
        private readonly IExpertRepository _expertRep;

        public TestimonialService(ITestimonialRepository repository, IMapper mapper, IExpertRepository expertRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _expertRep = expertRepository;
        }

        public async Task<TestimonialDTOSimpleResult> Create(TestimonialDTOCreate testimonial)
        {
            var model = _mapper.Map<TestimonialModel>(testimonial);
            var result = await _repository.InsertAsync(_mapper.Map<TestimonialEntity>(model));

            var testimonials = _mapper.Map<IEnumerable<TestimonialModel>>(await _repository.SelectByExpertAsync(result.ExpertId)).ToList();
            var expert = _mapper.Map<ExpertModel>(await _expertRep.SelectAsync(result.ExpertId));

            if(expert != null && testimonials.Count() > 0)
            {
                int qtd = testimonials.Count();
                double totalScore = testimonials.Sum(t => t.Stars);

                double expertScore = totalScore / qtd;
                expert.Stars = expertScore;

                var expertResult = await _expertRep.UpdateAsync(_mapper.Map<ExpertEntity>(expert));
            }

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
