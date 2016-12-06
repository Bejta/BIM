namespace BIMDomain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Manufactury",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Logo = c.Binary(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100),
                        guidCreated = c.Guid(nullable: false),
                        Created = c.DateTime(nullable: false),
                        guidUpdated = c.Guid(nullable: false),
                        Updated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Image = c.Binary(nullable: false),
                        ManufacturyID = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100),
                        guidCreated = c.Guid(nullable: false),
                        Created = c.DateTime(nullable: false),
                        guidUpdated = c.Guid(nullable: false),
                        Updated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Manufactury", t => t.ManufacturyID, cascadeDelete: true)
                .Index(t => t.ManufacturyID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Product", "ManufacturyID", "dbo.Manufactury");
            DropIndex("dbo.Product", new[] { "ManufacturyID" });
            DropTable("dbo.Product");
            DropTable("dbo.Manufactury");
        }
    }
}
