using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class AvailableDateEntity : BaseEntity
    {
        public Guid ExpertId { get; set; }
        public ExpertEntity Expert { get; set; }
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public IEnumerable<AvailableHourEntity> AvailableHours { get; set; }
    }
}
