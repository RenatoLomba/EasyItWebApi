using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Models
{
    public class PhotoModel : BaseModel
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public Guid ExpertId { get; set; }
    }
}
