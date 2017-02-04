using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using MySql.Data.Entity;

namespace MySQL_Connector
{
    // Code-Based Configuration and Dependency resolution
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    class ProductContext:DbContext
    {
        public virtual DbSet<Product> Products { get; set; }
        public ProductContext() : base("ProductDB")
        {

        }

 
    }
}
