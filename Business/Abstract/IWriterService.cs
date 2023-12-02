using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IWriterService
    {
        List<Writer> GetAll();

        Writer GetById(int id);

        void Add(Writer category);

        void Delete(Writer category);

        void Update(Writer category);

        Writer GetWriterInfo(Writer writer);

    }
}
