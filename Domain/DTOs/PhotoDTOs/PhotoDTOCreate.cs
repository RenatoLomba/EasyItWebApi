using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DTOs.PhotoDTOs
{
    public class PhotoDTOCreate
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public Guid ExpertId { get; set; }
    }
}
