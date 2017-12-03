# MySQL-EntityFramework-Code-First
<img src="https://www.mysql.com/common/logos/logo-mysql-170x115.png" height="100" width="150"/>

MySQL is a Database Management System from Oracle that currently supports Entity Framework through the MySQL ADO.NET Connector a fully-managed ADO.NET driver for MySQL.. I will go through steps in setting up MySQL with Entity framework 6.1.+ Using Visual Studio.
#### Note: 
This Tutorial also works with MariaDB.

**PREREQUISITES**
- Visual Studio<br/>
  Download Free Community Version Here (https://www.visualstudio.com/vs/community/)
- MySQL Server<br/>
  Download Here (https://dev.mysql.com/downloads/installer/)
- ADO.NET Driver for MySQL (Connector/NET)	
  Download Here (https://dev.mysql.com/downloads/connector/net/)
- Microsoft Entity Framework 6.1.+

**Adding Entity framework** 
</br>
Download Entity Framework From Nugget in Visual Studio,this will automatically reference all needed Microsoft Entity Framework Assemblies in your project
</br>
                             -OR
    </br>
Run this command in Package Management Console to download Entity Framework 
</br>
` Pm>   Install-Package EntityFramework`

**Reference MySQL Assemblies** (NB.These Assemblies are Available after installing the MYSQL Connector for .Net you can also get them on Nuget)
- MySQL.Data
- MySQL.Data.Entity


**Setting Up The Connection String in your `Web.Config` or `App.Config`** </br>
Set connection string to your existing MySql Database
```
<connectionStrings>
    <add name="SellRightDb" providerName="MySql.Data.MySqlClient"connectionString="server=localhost;userid=[your userid];password=[your password]database=sellright;persistsecurityinfo=True"/>
  </connectionStrings>
```

**Entity Framework Configuration**
<br>
Configuring MySQL to use Entity Framework add the block below to your `Web.config` or `App.config`
```
  <entityFramework>
    <defaultConnectionFactory type="System.Data.Entity.Infrastructure.SqlConnectionFactory, EntityFramework"/>
    <providers>
      <provider invariantName="MySql.Data.MySqlClient"
          type="MySql.Data.MySqlClient.MySqlProviderServices, MySql.Data.Entity.EF6"/>
      <provider invariantName="System.Data.SqlClient"
          type="System.Data.Entity.SqlServer.SqlProviderServices, EntityFramework.SqlServer"/>
    </providers>
  </entityFramework>
```

Create A Simple Model Class
```
 class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
    }
```


Creating Your DBContext Class

Import Namespaces
```
using System.Data.Entity;
using MySql.Data.Entity;
```
Configuring your Db Contex Class
```
// Code-Based Configuration and Dependency resolution
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    class SellRightContext :DbContext
    {
      
        //Add your Dbsets here
        public DbSet<Product>Products { get; set; }

        public SellRightContext()
              
           //Reference the name of your connection string
            : base("SellRightDb")
              {
            }
    }`
```

NB.

Enable Code First Migration
```
PM> Enable-Migrations
```

Add Code First Migration
```
PM> Add-Migration [Give Your Migration Settings A name]
```

Update Database (Specify Verbose to see the SQL Querry that is being executed)
```
PM> Update-Database -Verbose
```

You should see your Product Table Created in Your MySql Server

#### Note:
If you get a **System.TypeLoadException** when adding a migration, you should try to install a older version of the MySQL packages.
</br>
To do so, follow these steps:
1. Open the Package Manager Console: **Tools > NuGet Package Manager > Package Manager Console**
2. Uninstall the current Packages:
``` 
PM> Uninstall-Package MySQL.Data
PM> Uninstall-Package MySQL.Data.Entity 
```
3. Install the older packages:
```
PM> Install-Package MySQL.Data -Version [type in the tabulator and you'll see the available versions] `
PM> Install-Package MySQL.Data.Entity -Version [select the same version]
```
