using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Models
{
    public class FavoritesModel : BaseModel
    {
        public Guid UserId { get; set; }
        public Guid ExpertId { get; set; }
    }
}
