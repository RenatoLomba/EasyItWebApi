using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class PhotoEntity : BaseEntity
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public Guid ExpertId { get; set; }
        public ExpertEntity Expert { get; set; }
    }
}
