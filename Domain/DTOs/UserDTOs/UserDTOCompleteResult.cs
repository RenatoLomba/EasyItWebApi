using System;
using System.Collections.Generic;
using System.Text;
using Domain.DTOs.AppointmentDTOs;
using Domain.DTOs.FavoritesDTOs;
using Domain.DTOs.TestimonialDTOs;

namespace Domain.DTOs.UserDTOs
{
    public class UserDTOCompleteResult : UserDTOSimpleResult
    {
        public IEnumerable<TestimonialDTOSimpleResult> Testimonials { get; set; }
        public IEnumerable<AppointmentDTOSimpleResult> Appointments { get; set; }
        public IEnumerable<FavoritesDTOSimpleResult> Favorites { get; set; }
    }
}
