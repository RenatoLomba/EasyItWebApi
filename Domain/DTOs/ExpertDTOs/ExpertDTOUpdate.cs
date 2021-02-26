using System;
using System.Collections.Generic;
using System.Text;
using Domain.DTOs.PhotoDTOs;

namespace Domain.DTOs.ExpertDTOs
{
    public class ExpertDTOUpdate
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Avatar { get; set; }
        public string Location { get; set; }
        public double Stars { get; set; }
    }
}
