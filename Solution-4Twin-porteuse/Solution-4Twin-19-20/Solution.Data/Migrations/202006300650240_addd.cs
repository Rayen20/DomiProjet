namespace Solution.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Fichiers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        ImageUrl = c.String(),
                        Producer_ProducerId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Producers", t => t.Producer_ProducerId)
                .Index(t => t.Producer_ProducerId);
            
            CreateTable(
                "dbo.Producers",
                c => new
                    {
                        ProducerId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        DateOfBirth = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.ProducerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Fichiers", "Producer_ProducerId", "dbo.Producers");
            DropIndex("dbo.Fichiers", new[] { "Producer_ProducerId" });
            DropTable("dbo.Producers");
            DropTable("dbo.Fichiers");
        }
    }
}
