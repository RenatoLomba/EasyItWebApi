using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Models
{
    public class UserModel : BaseModel
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Role { get; set; }

        public string Password { get; set; }

        public string Avatar { get; set; }
    }
}
