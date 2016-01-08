namespace Entities
{
    public class Address : IArchivable
    {
        public int Id { get; set; }

        public string FirstLine { get; set; }

        public string SecondLine { get; set; }

        public string PostCode { get; set; }

        public string City { get; set; }

        public string Country { get; set; }
        
        public bool IsArchived { get; set; }
    }
}