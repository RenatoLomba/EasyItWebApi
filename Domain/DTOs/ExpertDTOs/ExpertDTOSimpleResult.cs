using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DTOs.ExpertDTOs
{
    public class ExpertDTOSimpleResult
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Avatar { get; set; }
        public double Stars { get; set; }
        public string Location { get; set; }
    }
}
