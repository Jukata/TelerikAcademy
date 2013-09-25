using SupermarketMySql.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Client
{
    public class MySqlManager
    {
       public static string GetProductNameById(int id)
       {
           using (SupermarketMySqlEntities db = new SupermarketMySqlEntities())
           {
               //var product = db.Products.Single(p => p.ProductsId == id);
               var product = db.Products.Where(p => p.ProductsId == id).First();
               return product.ProductName;
           }
       }
    }
}
