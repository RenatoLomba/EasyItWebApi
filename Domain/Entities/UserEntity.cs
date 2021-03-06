using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class UserEntity : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string Password { get; set; }
        public string Avatar { get; set; }
        public IEnumerable<TestimonialEntity> Testimonials { get; set; }
        public IEnumerable<AppointmentEntity> Appointments { get; set; }
        public IEnumerable<FavoritesEntity> Favorites { get; set; }
    }
}
