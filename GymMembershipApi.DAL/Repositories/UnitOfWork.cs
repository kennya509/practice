using GymMembershipApi.DAL.Data;
using GymMembershipApi.DAL.Entities;

namespace GymMembershipApi.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private IGenericRepository<Client>? _clients;
        private IGenericRepository<SubscriptionType>? _subscriptionTypes;
        private IGenericRepository<Membership>? _memberships;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public IGenericRepository<Client> Clients => _clients ??= new GenericRepository<Client>(_context);
        public IGenericRepository<SubscriptionType> SubscriptionTypes => _subscriptionTypes ??= new GenericRepository<SubscriptionType>(_context);
        public IGenericRepository<Membership> Memberships => _memberships ??= new GenericRepository<Membership>(_context);

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}