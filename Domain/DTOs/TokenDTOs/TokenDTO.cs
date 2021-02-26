using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DTOs.TokenDTOs
{
    public class TokenDTO
    {
        public bool Authenticated { get; set; }
        public string Message { get; set; }
        public string Token { get; set; }
        public DateTime Created { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
