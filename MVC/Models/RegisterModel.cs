using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class RegisterModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public RegisterModel InviterBy { get; set; }
        public string InviterCode { get; set; }

    }
}