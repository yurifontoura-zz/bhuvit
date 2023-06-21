using BasicBank.Domain.Entities;
using BasicBank.Domain.Repositories;
using BasicBank.Repository.EF;

namespace BasicBank.Repository.Repositories.Base
{
    public abstract class BaseRepository<EntityType> : IBaseRepository<EntityType> where EntityType : BaseEntity
    {
        protected EFContext _context;

        public BaseRepository(EFContext context)
        {
            _context = context;
        }

        public IQueryable<EntityType> List()
        {
            return _context.Set<EntityType>();
        }

        public EntityType Add(EntityType entity)
        {
            entity.Updated = DateTime.Now;
            return _context.Set<EntityType>().Add(entity).Entity;
        }
        public EntityType Update(EntityType entity)
        {
            entity.Updated = DateTime.Now;
            _context.Set<EntityType>().Attach(entity);
            _context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            return entity;
        }
        public void Delete(EntityType entity)
        {
            _context.Remove(entity);
        }

        public int Commit() => _context.SaveChanges();
    }
}
