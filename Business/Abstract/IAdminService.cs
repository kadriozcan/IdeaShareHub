﻿using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAdminService
    {
        List<Admin> GetAll();

        Admin GetById(int id);

        void Add(Admin admin);

        void Delete(Admin admin);

        void Update(Admin admin);

        Admin GetAdminInfo(Admin admin);
    }
}
