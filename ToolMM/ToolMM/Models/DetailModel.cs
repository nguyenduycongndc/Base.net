using System;

namespace ToolMM.Models
{
    public class DetailModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public int IsActive { get; set; }
    }
    public class DetailWalletModel
    {
        public int Id { get; set; }
        public string AddressWallet { get; set; }
        public int IsActive { get; set; }
    }
}
