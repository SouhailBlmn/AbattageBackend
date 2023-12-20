using Abattage_BackEnd.Models;
using Abattage_BackEnd.Repositories.Interfaces;

namespace Abattage_BackEnd.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<TypeBetail> TypesBetails { get; }
        IRepository<ArticleBetail> ArticlesBetails { get; }
        IRepository<Stabulation> Stabulations { get; }
        IRepository<Reception> Receptions { get; }
        IRepository<Carcasse> Carcasses { get; }
        IRepository<AnimalStatus> AnimalStatuses { get; }
        IRepository<ArticleStatus> ArticleStatuses { get; }
        IRepository<TypeAbattage> TypeAbattages { get; }
        IRepository<Chevillard> Chevillards { get; }
        IRepository<Client> Clients { get; }
        IRepository<Planification> Planifications { get; }
        Task SaveChangesAync();
    }

}