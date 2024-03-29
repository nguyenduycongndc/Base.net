﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace testPj.Models
{
    public class WalletModel
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string TAU { get; set; }
        public string BNB { get; set; }
        public int Selected { get; set; }
    }

    public class SearchWalletModel
    {
        [JsonPropertyName("start_number")]
        public int StartNumber { get; set; }
        [JsonPropertyName("page_size")]
        public int PageSize { get; set; }
    }
}
