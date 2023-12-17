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
        private readonly IDirectMessageDal _directMessageDal;

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

        public List<DirectMessage> GetReceivedMessages(string userMail)
        {
            return _directMessageDal.GetListByFilter(x => x.ReceiverMail == userMail);
        }

        public List<DirectMessage> GetSentMessages(string userMail)
        {
            return _directMessageDal.GetListByFilter(x => x.SenderMail == userMail);
        }

        public DirectMessage GetById(int id)
        {
            return _directMessageDal.GetByFilter(x => x.Id == id);
        }


        public void Update(DirectMessage directMessage)
        {
            throw new NotImplementedException();
        }

        public int GetNumOfReceivedMessages()
        {
            return _directMessageDal.GetListByFilter(x => x.ReceiverMail == "admin@gmail.com").Count();
        }

        public int GetNumOfSentMessages()
        {
            return _directMessageDal.GetListByFilter(x => x.SenderMail == "admin@gmail.com").Count();
        }
    }
}
