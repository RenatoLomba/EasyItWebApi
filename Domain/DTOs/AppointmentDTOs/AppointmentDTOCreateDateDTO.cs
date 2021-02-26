using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DTOs.AppointmentDTOs
{
    public class AppointmentDTOCreateDateDTO
    {
        public Guid AvailableHourId { get; set; }
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public int Hour { get; set; }
        public int Minutes { get; set; }
    }
}
