using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DTOs.AvailableHourDTOs
{
    public class AvailableHourDTOSimpleResult
    {
        public Guid Id { get; set; }
        public int Hour { get; set; }
        public int Minutes { get; set; }
    }
}
