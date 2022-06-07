using System;
using testPj.Models;

namespace testPj.Data
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public int IsActive { get; set; }
    }
}
