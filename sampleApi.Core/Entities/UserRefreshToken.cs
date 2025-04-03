using System;
using System.Collections.Generic;
using System.Text;

namespace sampleApi.Core.Entities
{
    public class UserRefreshToken
    {
        public int Id { get; set; }
        public Guid UsersId{ get; set; }
        public virtual Users Users { get; set; }
        public string RefreshToken { get; set; }
        public int RefreshTokenTimeOut { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsValid { get; set; }
    }
}
