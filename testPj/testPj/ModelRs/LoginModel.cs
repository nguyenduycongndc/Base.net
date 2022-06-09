using System;

namespace testPj.Models
{
    public class LoginModel
    {
        public string UserName { get; set; }

        public string Token { get; set; }
    }
    public class CurrentUserModel
    {
        public int? Id { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public int? RoleId { get; set; }
    }
}
