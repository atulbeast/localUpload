namespace Angular_Crud.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class delete1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Students", "IsActive", c => c.Boolean());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "IsActive", c => c.Boolean(nullable: false));
        }
    }
}
