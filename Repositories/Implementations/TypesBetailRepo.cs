using System.Linq.Expressions;
using Abattage_BackEnd.Data;
using Abattage_BackEnd.Models;
using Abattage_BackEnd.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Abattage_BackEnd.Repositories.Implementations
{
    public class TypesBetailRepo : IRepository<TypeBetail>
    {
        private readonly AppDbContext _context;
        public TypesBetailRepo(AppDbContext context)
        {
            this._context = context;
        }

        public async Task<TypeBetail> AddAsync(TypeBetail entity)
        {
            await this._context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public Task<IEnumerable<TypeBetail>> AddRangeAsync(IEnumerable<TypeBetail> entities)
        {
            throw new NotImplementedException();
        }

        public Task<TypeBetail> DeleteAsync(int id)
        {

            var typeBetail = this._context.TypesBetails.FirstOrDefaultAsync(t => t.Id == id);
            if (typeBetail == null)
            {
                return null;
            }
            this._context.TypesBetails.Remove(typeBetail.Result);
            this._context.SaveChanges();
            return Task.FromResult(typeBetail.Result);
        }

        public async Task<IEnumerable<TypeBetail>> GetAllAsync(params Expression<Func<TypeBetail, object>>[] includeProperties)
        {
            return await this._context.TypesBetails.AsNoTracking().OrderBy(t => t.Id).Select(t => new TypeBetail
            {
                Designation = t.Designation,
                Id = t.Id,
                Articles = t.Articles.Select(a => new ArticleBetail
                {
                    Id = a.Id,
                    Designation = a.Designation,
                }).ToList()
            }).ToListAsync();
        }

        public async Task<TypeBetail> GetByIdAsync(int id, params Expression<Func<TypeBetail, object>>[] includeProperties)
        {
            //Get listt of article ids for this type from ArticleTypeBetail table
            var articleIds = await this._context.ArticlesTypesBetails.AsNoTracking().Where(at => at.TypeBetailId == id).Select(at => at.ArticleBetailId).ToListAsync();
            //Get list of articles from ArticleBetail table
            List<ArticleBetail> articles = [];

            foreach (var articleId in articleIds)
            {
                var article = await this._context.ArticlesBetails.AsNoTracking().FirstOrDefaultAsync(a => a.Id == articleId);
                articles.Add(article);
            }

            return await this._context.TypesBetails.AsNoTracking().Select(t => new TypeBetail
            {
                Designation = t.Designation,
                Id = t.Id,
                Articles = articles

            }).FirstOrDefaultAsync(t => t.Id == id);
        }

        public Task<TypeBetail> UpdateAsync(TypeBetail entity)
        {



            this._context.TypesBetails.Update(entity);
            this._context.SaveChanges();
            return Task.FromResult(entity);


        }

        public Task<IEnumerable<TypeBetail>> UpdateRangeAsync(IEnumerable<TypeBetail> entities)
        {
            this._context.TypesBetails.UpdateRange(entities);
            this._context.SaveChanges();
            return Task.FromResult(entities);
        }
    }

}