using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Models
{
    public class AvailableHourModel : BaseModel
    {
        public Guid AvailableDateId { get; set; }
        public int Hour { get; set; }
        public int Minutes { get; set; }
    }
}
