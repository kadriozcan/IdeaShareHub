using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ITopicService
    {
        List<Topic> GetAll();

        List<Topic> GetAll(string p);

        List<Topic> GetAllByWriter(int id);

        Topic GetById(int id);

        void Add(Topic topic);

        void Delete(Topic topic);

        void Update(Topic topic);
    }
}
