using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class WriterManager : IWriterService
    {
        private readonly IWriterDal _writerDal;

        public WriterManager (IWriterDal writerDal)
        {
            _writerDal = writerDal;
        }

        public void Add(Writer category)
        {
            _writerDal.Add(category);
        }

        public void Delete(Writer category)
        {
            _writerDal.Delete(category);
        }

        public List<Writer> GetAll()
        {
            return _writerDal.GetAll();
        }

        public Writer GetById(int id)
        {
            return _writerDal.GetByFilter(w => w.Id == id);
        }

        public void Update(Writer category)
        {
            _writerDal.Update(category);
        }

        public Writer GetWriterInfo(Writer writer)
        {
            return _writerDal.GetByFilter(x => x.Username == writer.Username && x.Password == writer.Password);
        }
    }
}
