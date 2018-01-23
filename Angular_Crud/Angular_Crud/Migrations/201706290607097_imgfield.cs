namespace Angular_Crud.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class imgfield : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "LogoUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "LogoUrl");
        }
    }
}
