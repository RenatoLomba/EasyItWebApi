using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DTOs.PhotoDTOs
{
    public class PhotoDTOSimpleResult
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
    }
}
