using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DTOs.FavoritesDTOs
{
    public class FavoritesDTOCreate
    {
        public Guid UserId { get; set; }
        public Guid ExpertId { get; set; }
    }
}
