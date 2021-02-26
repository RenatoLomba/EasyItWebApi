using System;
using System.Collections.Generic;
using System.Text;
using Domain.DTOs.ExpertDTOs;

namespace Domain.DTOs.ServiceDTOs
{
    public class ServiceDTOCompleteResult : ServiceDTOSimpleResult
    {
        public DateTime? CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public ExpertDTOSimpleResult Expert { get; set; }
    }
}
