namespace Entities
{
    public class MailingListContact
    {
        public int Id { get; set; }

        public virtual Contact Contact { get; set; }
        public int ContactId { get; set; }

        public virtual MailingList MailingList { get; set; }
        public int MailingListId { get; set; }
    }
}