namespace GymMembershipApi.Domain.Entities;

    public class Membership
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public Client? Client { get; set; } 
        public int SubscriptionTypeId { get; set; }
        public SubscriptionType? SubscriptionType { get; set; } 
        public DateTime PurchaseDate { get; set; }
        public DateTime EndDate { get; set; }
    }
