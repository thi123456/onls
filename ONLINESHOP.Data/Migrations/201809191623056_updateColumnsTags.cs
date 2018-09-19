namespace ONLINESHOP.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateColumnsTags : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Tags", c => c.String());
            DropColumn("dbo.Products", "Tabs");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Tabs", c => c.String());
            DropColumn("dbo.Products", "Tags");
        }
    }
}
