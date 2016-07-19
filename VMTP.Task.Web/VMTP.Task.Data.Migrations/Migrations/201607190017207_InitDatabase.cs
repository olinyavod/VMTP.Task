namespace VMTP.Task.Data.Migrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitDatabase : DbMigration
    {
        public override void Up()
        {
			CreateTable(
			   "dbo.Operations",
			   c => new
			   {
				   Id = c.Int(nullable: false, identity: true),
				   Name = c.String(nullable: false, maxLength: 128),
				   Price = c.Decimal(nullable: false, precision: 18, scale: 2),
			   })
			   .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 128),
                        Debt = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CustomerOperations",
                c => new
                    {
                        CustomerId = c.Int(nullable: false),
                        OperationId = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CustomerId, t.OperationId })
                .ForeignKey("dbo.Operations", t => t.OperationId, cascadeDelete: true)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.OperationId);
            
           
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CustomerOperations", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.CustomerOperations", "OperationId", "dbo.Operations");
            DropIndex("dbo.CustomerOperations", new[] { "OperationId" });
            DropIndex("dbo.CustomerOperations", new[] { "CustomerId" });
            DropTable("dbo.Operations");
            DropTable("dbo.CustomerOperations");
            DropTable("dbo.Customers");
        }
    }
}
