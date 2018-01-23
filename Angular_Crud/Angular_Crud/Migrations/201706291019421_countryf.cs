namespace Angular_Crud.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class countryf : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Students", "Country", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "Country", c => c.String());
        }
    }
}
