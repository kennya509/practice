using GymMembershipApi.Domain.Entities;

namespace GymMembershipApi.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Client> Clients { get; }
        IGenericRepository<SubscriptionType> SubscriptionTypes { get; }
        IGenericRepository<Membership> Memberships { get; }

        Task<int> SaveChangesAsync();
    }
}