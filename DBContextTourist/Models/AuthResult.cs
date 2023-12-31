﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBContextTourist.Models
{
    public class AuthResult
    {
        public string Token { get; set; }
        public bool Result { get; set; }
        public string UserId { get; set; }
        public int CompanyId { get; set; }
        public List<string> Errors { get; set; }
    }
}
