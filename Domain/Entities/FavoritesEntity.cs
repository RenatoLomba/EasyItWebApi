using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class FavoritesEntity : BaseEntity
    {
        public Guid UserId { get; set; }
        public UserEntity User { get; set; }
        public Guid ExpertId { get; set; }
        public ExpertEntity Expert { get; set; }
    }
}
