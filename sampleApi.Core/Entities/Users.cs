using System;
using System.Collections.Generic;
using System.Text;

namespace sampleApi.Core.Entities
{
    public class Users
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Passsword { get; set; }
        public string PasswordSolt { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateTime? LastLoginDate { get; set; }
    }
}
