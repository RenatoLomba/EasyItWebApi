using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Models
{
    public class TestimonialModel : BaseModel
    {
        public Guid UserId { get; set; }
        public Guid ExpertId { get; set; }
        public string Description { get; set; }
        public double Stars { get; set; }
    }
}
