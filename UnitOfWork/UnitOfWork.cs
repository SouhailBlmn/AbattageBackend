using Abattage_BackEnd.Data;
using Abattage_BackEnd.Models;
using Abattage_BackEnd.Repositories.Implementations;
using Abattage_BackEnd.Repositories.Interfaces;

namespace Abattage_BackEnd.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private IRepository<TypeBetail> _typesBetails;
        private IRepository<ArticleBetail> _articlesBetails;
        private IRepository<Stabulation> _stabulations;
        private IRepository<Reception> _receptions;
        private IRepository<Carcasse> _carcasses;
        private IRepository<AnimalStatus> _animalStatuses;
        private IRepository<ArticleStatus> _articleStatuses;
        private IRepository<TypeAbattage> _typeAbattages;
        private IRepository<Chevillard> _chevillards;
        private IRepository<Client> _clients;
        private IRepository<Planification> _planifications;
        private IRepository<ArticleParAnimal> _articleParAnimals;
        private IRepository<ArticleTypeBetail> _articlesTypeBetails;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public IRepository<TypeBetail> TypesBetails => _typesBetails ??= new TypesBetailRepo(_context);

        public IRepository<ArticleBetail> ArticlesBetails => _articlesBetails ??= new Repository<ArticleBetail>(_context);

        public IRepository<Stabulation> Stabulations => _stabulations ??= new Repository<Stabulation>(_context);

        public IRepository<Reception> Receptions => _receptions ??= new Repository<Reception>(_context);

        public IRepository<Carcasse> Carcasses => _carcasses ??= new Repository<Carcasse>(_context);

        public IRepository<AnimalStatus> AnimalStatuses => _animalStatuses ??= new Repository<AnimalStatus>(_context);

        public IRepository<ArticleStatus> ArticleStatuses => _articleStatuses ??= new Repository<ArticleStatus>(_context);

        public IRepository<TypeAbattage> TypeAbattages => _typeAbattages ??= new Repository<TypeAbattage>(_context);

        public IRepository<Chevillard> Chevillards => _chevillards ??= new Repository<Chevillard>(_context);

        public IRepository<Client> Clients => _clients ??= new Repository<Client>(_context);

        public IRepository<Planification> Planifications => _planifications ??= new Repository<Planification>(_context);

        public IRepository<ArticleParAnimal> ArticleParAnimals => _articleParAnimals ??= new Repository<ArticleParAnimal>(_context);

        public IRepository<ArticleTypeBetail> ArticlesTypeBetails => _articlesTypeBetails ??= new Repository<ArticleTypeBetail>(_context);

        public async Task SaveChangesAync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }

}