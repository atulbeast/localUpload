namespace Angular_Crud.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class field : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "City", c => c.String());
            AddColumn("dbo.Students", "Email", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "Email");
            DropColumn("dbo.Students", "City");
        }
    }
}
