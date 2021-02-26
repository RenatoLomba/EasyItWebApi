using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DTOs.UserDTOs
{
    public class UserDTOSimpleResult
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public DateTime? CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public string Avatar { get; set; }
    }
}
