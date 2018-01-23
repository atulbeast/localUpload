namespace Angular_Crud.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class field1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "Country", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "Country");
        }
    }
}
