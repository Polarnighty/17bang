using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SRV.ViewModel
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string InviterBy { get; set; }
        public string InviterCode { get; set; }

    }
}