using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Models
{
    public class AppointmentModel : BaseModel
    {
        public Guid UserId { get; set; }
        public Guid ExpertId { get; set; }
        public Guid ServiceId { get; set; }
        public DateTime Date { get; set; }
    }
}
