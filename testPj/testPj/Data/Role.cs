using System;
using testPj.Models;

namespace testPj.Data
{
    public class Role
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string Token { get; set; }
        public bool IsActive { get; set; }
    }
}
