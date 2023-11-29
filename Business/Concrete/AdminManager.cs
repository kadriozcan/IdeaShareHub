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
    public class AdminManager : IAdminService
    {
        private readonly IAdminDal _adminDal;

        public AdminManager(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }

        public void Add(Admin admin)
        {
            throw new NotImplementedException();
        }

        public void Delete(Admin admin)
        {
            throw new NotImplementedException();
        }

        public Admin GetAdminInfo(Admin admin)
        {
            return _adminDal.GetByFilter(x => x.Username == admin.Username && x.Password == admin.Password);
        }

        public List<Admin> GetAll()
        {
            return _adminDal.GetAll();
        }

        public Admin GetById(int id)
        {
            return _adminDal.GetByFilter(x => x.Id == id);
        }

        public void Update(Admin admin)
        {
            throw new NotImplementedException();
        }
    }
}
