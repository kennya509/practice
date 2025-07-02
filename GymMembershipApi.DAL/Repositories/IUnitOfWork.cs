using GymMembershipApi.DAL.Entities;

namespace GymMembershipApi.DAL.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Client> Clients { get; }
        IGenericRepository<SubscriptionType> SubscriptionTypes { get; }
        IGenericRepository<Membership> Memberships { get; }
        Task<int> SaveChangesAsync();
    }
}