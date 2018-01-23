namespace Angular_Crud.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class field4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        SId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.States",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SName = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Students", "State", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "State");
            DropTable("dbo.States");
            DropTable("dbo.Cities");
        }
    }
}
