using CSharpEgitimKampi301.BusinessLayer.Abstract;
using CSharpEgitimKampi301.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpEgitimKampi301.BusinessLayer.Concrete
{
    public class CustomerManager : ICustomerService
    {
        public void TDelete(Customer entity)
        {
            throw new NotImplementedException();
        }
        public List<Customer> TGetAll()
        {
            throw new NotImplementedException();
        }
        public Customer TGetById(int id)
        {
            throw new NotImplementedException();
        }
        public void TInsert(Customer entity)
        {
            //Validation Kuralı
            if (entity.CustomerName != "" && entity.CustomerName.Length >= 3 &&
                entity.CustomerCity != null && entity.CustomerSurname != "" && entity.CustomerName.Length <= 30)
            {
                //ekleme işlemi yap
            }
            else
            {
                //hata mesajı ver
            }
        }
        public void TUpdate(Customer entity)
        {
            throw new NotImplementedException();
        }
    }
}
