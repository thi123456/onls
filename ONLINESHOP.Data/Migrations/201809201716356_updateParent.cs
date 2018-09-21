namespace ONLINESHOP.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateParent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductCategories", "ParentID", c => c.Int());
            DropColumn("dbo.ProductCategories", "PatentID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProductCategories", "PatentID", c => c.Int());
            DropColumn("dbo.ProductCategories", "ParentID");
        }
    }
}
