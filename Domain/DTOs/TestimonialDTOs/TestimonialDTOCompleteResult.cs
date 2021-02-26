using System;
using System.Collections.Generic;
using System.Text;
using Domain.DTOs.ExpertDTOs;
using Domain.DTOs.UserDTOs;
using Domain.Entities;

namespace Domain.DTOs.TestimonialDTOs
{
    public class TestimonialDTOCompleteResult : TestimonialDTOSimpleResult
    {
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public UserDTOSimpleResult User { get; set; }
        public ExpertDTOSimpleResult Expert { get; set; }
    }
}
