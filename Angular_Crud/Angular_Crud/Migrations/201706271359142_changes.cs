namespace Angular_Crud.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changes : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Students", "State", c => c.Int(nullable: false));
            AlterColumn("dbo.Students", "City", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "City", c => c.String());
            AlterColumn("dbo.Students", "State", c => c.String());
        }
    }
}
