namespace Solution.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addddddd : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Fichiers", "Producer_ProducerId", "dbo.Producers");
            DropIndex("dbo.Fichiers", new[] { "Producer_ProducerId" });
            DropColumn("dbo.Fichiers", "Producer_ProducerId");
            DropTable("dbo.Producers");
        }
        
        public override void Down()
        {
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
            
            AddColumn("dbo.Fichiers", "Producer_ProducerId", c => c.Int());
            CreateIndex("dbo.Fichiers", "Producer_ProducerId");
            AddForeignKey("dbo.Fichiers", "Producer_ProducerId", "dbo.Producers", "ProducerId");
        }
    }
}
