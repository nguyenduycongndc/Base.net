﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace testPj.Models
{
    public class AuthModel
    {
        [JsonPropertyName("token")]
        public string Token { get; set; }

        public string host { get; set; }
        public string actionmenu { get; set; }
        public string currentUsers { get; set; }
    }
}
