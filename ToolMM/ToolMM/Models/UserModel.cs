using System;
using System.Collections.Generic;

namespace ToolMM.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public int IsActive { get; set; }
    }
    public class UserRsModel
    {
        public List<UserModel> Data { get; set; }
        public int Count { get; set; }
    }
}
