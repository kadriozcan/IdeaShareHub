using Business.Abstract;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class EntryManager : IEntryService
    {
        IEntryDal _entryDal;

        public EntryManager(IEntryDal entryDal)
        {
            _entryDal = entryDal;
        }

        public void Add(Entry entry)
        {
            _entryDal.Add(entry);
        }

        public void Delete(Entry entry)
        {
            _entryDal.Delete(entry);
        }

        public List<Entry> GetAll()
        {
            return _entryDal.GetAll();
        }

        public List<Entry> GetAllByWriter(int id)
        {

            return _entryDal.GetListByFilter(x => x.WriterId == id);
        }

        public Entry GetById(int id)
        {
            return _entryDal.GetByFilter(e => e.Id == id);
        }

        public List<Entry> GetListByTopic(int topicId)
        {
            return _entryDal.GetListByFilter(e => e.TopicId == topicId);
        }

        public void Update(Entry entry)
        {
            _entryDal.Update(entry);
        }
    }
}
