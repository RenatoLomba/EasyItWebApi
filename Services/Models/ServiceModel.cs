using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Models
{
    public class ServiceModel : BaseModel
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public Guid ExpertId { get; set; }
    }
}
