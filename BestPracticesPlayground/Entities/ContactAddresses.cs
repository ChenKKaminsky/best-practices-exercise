using System;

namespace Entities
{
    public class ContactAddresses
    {
        public int Id { get; set; }

        public virtual Address Address { get; set; }
        public int AddressId { get; set; }

        public virtual Contact Contact { get; set; }
        public int ContactId { get; set; }
    }
}