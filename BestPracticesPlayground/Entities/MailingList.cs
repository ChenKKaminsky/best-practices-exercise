using System.Collections.Generic;

namespace Entities
{
    public class MailingList
    {
        public MailingList()
        {
            MailingListContacts = new List<MailingListContact>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<MailingListContact> MailingListContacts { get; set; }
    }
}