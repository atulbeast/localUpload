namespace Angular_Crud.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class field2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "PhnNo", c => c.String());
            AddColumn("dbo.Students", "DOB", c => c.String());
            AddColumn("dbo.Students", "Gender", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "Gender");
            DropColumn("dbo.Students", "DOB");
            DropColumn("dbo.Students", "PhnNo");
        }
    }
}
