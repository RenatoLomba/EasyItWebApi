using System;
using System.Collections.Generic;
using System.Text;
using Domain.DTOs.ExpertDTOs;
using Domain.DTOs.ServiceDTOs;

namespace Domain.DTOs.AppointmentDTOs
{
    public class AppointmentDTOSimpleResult
    {
        public Guid Id { get; set; }
        public DateTime CreateAt { get; set; }
        public Guid ExpertId { get; set; }
        public ExpertDTOSimpleResult Expert { get; set; }
        public Guid ServiceId { get; set; }
        public ServiceDTOSimpleResult Service { get; set; }
        public DateTime Date { get; set; }
    }
}
