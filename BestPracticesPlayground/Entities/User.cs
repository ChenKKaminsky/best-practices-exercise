using System;
using System.Collections.Generic;

namespace Entities
{
    public class User
    {
        public User()
        {
            AccessibleAccounts = new List<AccountUsers>();
        }
        public int Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public DateTime LastLogin { get; set; }

        public virtual ICollection<AccountUsers> AccessibleAccounts { get; set; }
    }
}