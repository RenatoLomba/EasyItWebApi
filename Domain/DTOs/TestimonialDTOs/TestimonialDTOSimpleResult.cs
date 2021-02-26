using System;
using System.Collections.Generic;
using System.Text;
using Domain.DTOs.UserDTOs;

namespace Domain.DTOs.TestimonialDTOs
{
    public class TestimonialDTOSimpleResult
    {
        public Guid Id { get; set; }
        public UserDTOSimpleResult User { get; set; }
        public Guid ExpertId { get; set; }
        public string Description { get; set; }
        public double Stars { get; set; }
    }
}
