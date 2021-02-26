using System;
using System.Collections.Generic;
using System.Text;
using Domain.DTOs.AppointmentDTOs;
using Domain.DTOs.TestimonialDTOs;
using Domain.DTOs.TokenDTOs;

namespace Domain.DTOs.UserDTOs
{
    public class UserDTOSignResult : UserDTOSimpleResult
    {
        public TokenDTO Token { get; set; }
        public IEnumerable<TestimonialDTOSimpleResult> Testimonials { get; set; }
        public IEnumerable<AppointmentDTOSimpleResult> Appointments { get; set; }
    }
}
