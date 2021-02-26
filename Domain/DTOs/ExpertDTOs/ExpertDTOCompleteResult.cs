using System;
using System.Collections.Generic;
using System.Text;
using Domain.DTOs.AppointmentDTOs;
using Domain.DTOs.AvailableDateDTOs;
using Domain.DTOs.PhotoDTOs;
using Domain.DTOs.ServiceDTOs;
using Domain.DTOs.TestimonialDTOs;

namespace Domain.DTOs.ExpertDTOs
{
    public class ExpertDTOCompleteResult : ExpertDTOSimpleResult
    {
        public string Email { get; set; }
        public string Role { get; set; }
        public DateTime? CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public IEnumerable<ServiceDTOSimpleResult> Services { get; set; }
        public IEnumerable<PhotoDTOSimpleResult> Photos { get; set; }
        public IEnumerable<TestimonialDTOSimpleResult> Testimonials { get; set; }
        public IEnumerable<AvailableDateDTOSimpleResult> AvailableDates { get; set; }
        public IEnumerable<AppointmentDTOSimpleResult> Appointments { get; set; }
    }
}
