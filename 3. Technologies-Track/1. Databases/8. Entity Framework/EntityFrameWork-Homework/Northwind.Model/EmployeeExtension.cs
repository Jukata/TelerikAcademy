using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Model
{
    public partial class Employee
    {
        //8. By inheriting the Employee entity class create a class which allows employees 
        //to access their corresponding territories as property of type EntitySet<T>.

        //public partial class Employee
        //{
        //    private EntitySet<Territory> entityTerritories;

        //    public EntitySet<Territory> EntityTerritories
        //    {
        //        get
        //        {
        //            var employeeTerritories = this.Territories;
        //            EntitySet<Territory> entityTerritories = new EntitySet<Territory>();
        //            entityTerritories.AddRange(employeeTerritories);
        //            return entityTerritories;
        //        }
        //    }
        //}
    }
}
