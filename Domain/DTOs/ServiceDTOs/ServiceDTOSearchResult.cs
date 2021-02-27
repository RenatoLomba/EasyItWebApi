using System;
using System.Collections.Generic;
using System.Text;
using Domain.DTOs.ExpertDTOs;

namespace Domain.DTOs.ServiceDTOs
{
    public class ServiceDTOSearchResult : ServiceDTOSimpleResult
    {
        public ExpertDTOSimpleResult Expert { get; set; }
    }
}
