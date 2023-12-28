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
    public class TopicManager : ITopicService
    {
        private readonly ITopicDal _topicDal;

        public TopicManager (ITopicDal topicDal)
        {
            _topicDal = topicDal;
        }

        public void Add(Topic topic)
        {
            _topicDal.Add(topic);
        }

        public void Delete(Topic topic)
        {
            topic.Status = false;
            _topicDal.Update(topic);
        }

        public List<Topic> GetAll()
        {
            return _topicDal.GetAll();
        }

        public List<Topic> GetAll(string p)
        {
            return _topicDal.GetListByFilter(x => x.Name.Contains(p));
        }

        public List<Topic> GetAllByWriter(int id)
        {
            return _topicDal.GetListByFilter(x => x.WriterId == id && x.Status==true);
        }

        public Topic GetById(int id)
        {
            return _topicDal.GetByFilter(t => t.Id == id);
        }

        public void Update(Topic topic)
        {
            _topicDal.Update(topic);
        }
    }
}
