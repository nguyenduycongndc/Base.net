using System;

namespace testPj.Models
{
    public class CreateModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
    }
    public class CreateWalletModel
    {
        public string AddressWallet { get; set; }
        public string TAU { get; set; }
        public string BNB { get; set; }
        public int IsCheck { get; set; }
    }
    public class CheckedWalletModel
    {
        public int Id { get; set; }
        public int Checked { get; set; }
    }
}
