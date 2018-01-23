namespace Angular_Crud.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class field3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "Btech", c => c.Boolean(nullable: false));
            AddColumn("dbo.Students", "Bsc", c => c.Boolean(nullable: false));
            AddColumn("dbo.Students", "Bca", c => c.Boolean(nullable: false));
            AddColumn("dbo.Students", "Ba", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "Ba");
            DropColumn("dbo.Students", "Bca");
            DropColumn("dbo.Students", "Bsc");
            DropColumn("dbo.Students", "Btech");
        }
    }
}
