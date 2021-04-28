namespace SpodIgly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ShortDescriptionRemoved : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Albums", "ShortDescription");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Albums", "ShortDescription", c => c.String());
        }
    }
}
