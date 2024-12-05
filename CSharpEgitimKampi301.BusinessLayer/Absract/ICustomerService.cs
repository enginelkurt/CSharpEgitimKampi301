using CSharpEgitimKampi301.EFProject;
using CSharpEgitimKampi301.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Customer = CSharpEgitimKampi301.EntityLayer.Concrete.Customer;

namespace CSharpEgitimKampi301.BusinessLayer.Absract
{
    public interface ICustomerService : IGenericService <Customer>
    {
    }
}
