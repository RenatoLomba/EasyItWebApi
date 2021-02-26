using System;
using System.Collections.Generic;
using System.Text;
using Domain.DTOs.AvailableHourDTOs;

namespace Domain.DTOs.AvailableDateDTOs
{
    public class AvailableDateDTOCreate
    {
        public Guid ExpertId { get; set; }
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public IEnumerable<AvailableHourDTOCreate> AvailableHours { get; set; }
    }
}
