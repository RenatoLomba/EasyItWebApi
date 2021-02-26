using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Security
{
    public class TokenConfigurations
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public double Seconds { get; set; }
    }
}
