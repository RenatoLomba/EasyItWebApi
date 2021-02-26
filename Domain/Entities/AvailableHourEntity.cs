using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class AvailableHourEntity : BaseEntity
    {
        public Guid AvailableDateId { get; set; }
        public AvailableDateEntity AvailableDate { get; set; }
        public int Hour { get; set; }
        public int Minutes { get; set; }
    }
}
