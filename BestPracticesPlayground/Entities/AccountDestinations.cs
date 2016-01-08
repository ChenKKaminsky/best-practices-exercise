namespace Entities
{
    public class AccountDestinations
    {
        public int Id { get; set; }

        public string AddressNickname { get; set; }

        public virtual Account Account { get; set; }
        public int AccountId { get; set; }

        public virtual Address Address { get; set; }
        public int AddressId { get; set; }
    }
}