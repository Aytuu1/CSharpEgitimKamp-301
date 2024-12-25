using CSharpEgitimKampı301.DataAccessLayer.Abstract;
using CSharpEgitimKampı301.DataAccessLayer.Context;
using CSharpEgitimKampı301.DataAccessLayer.Repositories;
using CSharpEgitimKampı301.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpEgitimKampı301.DataAccessLayer.EntityFrameWork
{
  public class EfProductDal : GenericRepository<Product>, IProductDal
  {
    public List<Object> getProductWithCategory()
    {
      var context = new CampContext();
      var values = context.Products
        .Select(x=>new 
      {
          
        ProductID=x.ProductID,
        ProductDescription=x.ProductDescription,
        ProductName=x.ProductName,
        ProductPrice=x.ProductPrice,
        ProductStock=x.ProductStock,
        CategoryName=x.Category.CategoryName
        
      }).ToList();
      return values.Cast<object>().ToList();
    }
  }
}
