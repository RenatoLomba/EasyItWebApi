using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.DTOs.TestimonialDTOs;

namespace Domain.Interfaces.AppServicesInterfaces
{
    public interface ITestimonialService
    {
        public Task<TestimonialDTOSimpleResult> Get(Guid id);
        public Task<TestimonialDTOCompleteResult> GetComplete(Guid id);
        public Task<IEnumerable<TestimonialDTOSimpleResult>> GetAll();
        public Task<TestimonialDTOSimpleResult> Create(TestimonialDTOCreate testimonial);
        public Task<bool> Delete(Guid id);
    }
}
