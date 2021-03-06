using System;
using System.Collections.Generic;
using System.Text;
using Domain.DTOs.ExpertDTOs;

namespace Domain.DTOs.FavoritesDTOs
{
    public class FavoritesDTOSimpleResult
    {
        public Guid Id { get; set; }
        public ExpertDTOSimpleResult Expert { get; set; }
    }
}
