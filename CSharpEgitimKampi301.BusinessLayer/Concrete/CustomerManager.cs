using CSharpEgitimKampi301.BusinessLayer.Absract;
using CSharpEgitimKampi301.DataAccessLayer.Abstract;
using CSharpEgitimKampi301.EFProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpEgitimKampi301.BusinessLayer.Concrete
{
    public class CustomerManager : ICustomerService
    {
        private readonly ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public void TDelete(EntityLayer.Concrete.Customer entity)
        {
           _customerDal.Delete(entity);
        }

        public List<EntityLayer.Concrete.Customer> TGetAll()
        {
            // if(yetki varsa)
            {
                //ekleme yapılır yetkı yoksa yapılmaz.
            }
            return _customerDal.GetAll();
        }

        public EntityLayer.Concrete.Customer TGetById(int id)
        {
            return _customerDal.GetById(id);
        }

        public void TInsert(EntityLayer.Concrete.Customer entity)
        {
           if(entity.CustomerName!= "" && entity.CustomerName.Length >=3 && entity.CustomerCity!=null &&  entity.CustomerSurname!= "" && entity.CustomerName.Length <=30)

            {
                _customerDal.Insert(entity);
            }
            else
            {
                 // hata mesaji cikar.
            }
        }

        public void TUpdate(EntityLayer.Concrete.Customer entity)
        {

            if(entity.CustomerId!=0 && entity.CustomerCity.Length>=3)
            {
                _customerDal.Update(entity);
            }
            else
            {
                //hata mesajı
            }
        }
    }
}
