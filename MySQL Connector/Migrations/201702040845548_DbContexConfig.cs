namespace MySQL_Connector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DbContexConfig : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProdictId = c.Int(nullable: false, identity: true),
                        ProductName = c.String(unicode: false),
                        Price = c.Double(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProdictId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Products");
        }
    }
}
