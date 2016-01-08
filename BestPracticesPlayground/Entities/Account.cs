using System.Collections.Generic;

namespace Entities
{
    public class Account
    {
        public Account()
        {
            Contacts = new List<Contact>();
            OrdersHistory = new List<Orders>();
            MailingLists = new List<MailingList>();

            AccountDestinations = new List<AccountDestinations>();
        }

        public int Id { get; set; }

        public string AccountName { get; set; }

        public virtual ICollection<AccountDestinations> AccountDestinations { get; set; }

        public virtual ICollection<Contact> Contacts { get; set; }

        public virtual ICollection<MailingList> MailingLists { get; set; }

        public virtual ICollection<Orders> OrdersHistory { get; set; }

        public virtual Settings Settings { get; set; }
    }
}
