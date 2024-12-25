using CSharpEgitimKampı301.DataAccessLayer.Abstract;
using CSharpEgitimKampı301.DataAccessLayer.Repositories;
using CSharpEgitimKampı301.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpEgitimKampı301.DataAccessLayer.EntityFrameWork
{
  public class EfCustomerDal:GenericRepository<Customer>,ICustomerDal
  {
  }
}
