﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DTOs.UserDTOs
{
    public class UserDTOCreate
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Avatar { get; set; }
    }
}
