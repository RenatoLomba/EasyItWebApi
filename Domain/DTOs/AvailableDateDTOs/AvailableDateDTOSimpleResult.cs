using System;
using System.Collections.Generic;
using System.Text;
using Domain.DTOs.AvailableHourDTOs;

namespace Domain.DTOs.AvailableDateDTOs
{
    public class AvailableDateDTOSimpleResult
    {
        public Guid Id { get; set; }
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public IEnumerable<AvailableHourDTOSimpleResult> AvailableHours { get; set; }
    }
}
