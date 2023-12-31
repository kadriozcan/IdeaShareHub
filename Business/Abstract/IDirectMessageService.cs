﻿using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IDirectMessageService
    {
        List<DirectMessage> GetReceivedMessages(string userMail);

        List<DirectMessage> GetSentMessages(string userMail);

        DirectMessage GetById(int id);

        void Add(DirectMessage directMessage);

        void Delete(DirectMessage directMessage);

        void Update(DirectMessage directMessage);

        int GetNumOfReceivedMessages();
        int GetNumOfSentMessages();
    }
}
