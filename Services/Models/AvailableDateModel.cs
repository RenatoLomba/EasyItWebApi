using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Models
{
    public class AvailableDateModel : BaseModel
    {
        public Guid ExpertId { get; set; }
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
    }
}
