using DataAccess.Abstract;
using DataAccess.Concrete.Repositories;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfAboutDal : EfRepositoryBase<About>, IAboutDal
    {
    }
}
