using System;

namespace ToolMM.Models
{
    public class ChangePassWordModel
    {
        public int Id { get; set; }
        public string PassWordOld { get; set; }
        public string PassWordNew { get; set; }
        public string ConfirmPassWordNew { get; set; }
    }
}
