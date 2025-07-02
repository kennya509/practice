﻿namespace GymMembershipApi.DAL.Entities;
    public class SubscriptionType
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int DurationInDays { get; set; }
    }
