﻿using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IEntryService
    {
        List<Entry> GetAll();

        List<Entry> GetAll(string p);

        Entry GetById(int id);

        List<Entry> GetListByTopic(int id);

        List<Entry> GetAllByWriter(int id);

        void Add(Entry entry);

        void Delete(Entry entry);

        void Update(Entry entry);
    }
}
