namespace Persistence.Repositories;

public class ModelRepository : EfRepositoryBase<Model, BaseDbContext>, IModelRepository
{
    public ModelRepository(BaseDbContext context) : base(context)
    {
    }
}
