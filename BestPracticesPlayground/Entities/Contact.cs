using System.Collections.Generic;

namespace Entities
{
    public class Contact : IArchivable
    {
        public Contact()
        {
            ContactAddresses = new List<ContactAddresses>();
        }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public int? PrimaryAddressId { get; set; }

        public virtual ICollection<ContactAddresses> ContactAddresses { get; set; }

        public bool IsArchived { get; set; }
    }
}