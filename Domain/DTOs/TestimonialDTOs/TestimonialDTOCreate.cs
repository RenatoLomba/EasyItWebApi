using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DTOs.TestimonialDTOs
{
    public class TestimonialDTOCreate
    {
        public Guid UserId { get; set; }
        public Guid ExpertId { get; set; }
        public string Description { get; set; }
        public double Stars { get; set; }
    }
}
