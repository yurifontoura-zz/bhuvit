namespace BasicBank.Domain.Repositories
{
    public interface IBaseRepository<EntityType>
    {
        EntityType Add(EntityType entity);
        EntityType Update(EntityType entity);
        IQueryable<EntityType> List();
        void Delete(EntityType entity);
        int Commit();
    }
}
