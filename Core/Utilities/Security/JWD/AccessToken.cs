﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.JWD
{
    public class AccessToken
    {
      
        public DateTime Expiration { get; set; }
        public string Token { get; internal set; }
    }
}
