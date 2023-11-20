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
    public class DirectMessageManager : IDirectMessageService
    {
        IDirectMessageDal _directMessageDal;

        public DirectMessageManager(IDirectMessageDal directMessageDal)
        {
            _directMessageDal = directMessageDal;
        }

        public void Add(DirectMessage directMessage)
        {
            _directMessageDal.Add(directMessage);
        }

        public void Delete(DirectMessage directMessage)
        {
            _directMessageDal.Delete(directMessage);
        }

        public List<DirectMessage> GetAll()
        {
           return _directMessageDal.GetAll();
        }

        public DirectMessage GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(DirectMessage directMessage)
        {
            throw new NotImplementedException();
        }
    }
}
