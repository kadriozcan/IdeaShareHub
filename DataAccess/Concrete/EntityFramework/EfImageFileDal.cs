using DataAccess.Abstract;
using DataAccess.Concrete.Repositories;
using Entity.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfImageFileDal : EfRepositoryBase<ImageFile>, IImageFileDal
    {
    }
}
