namespace MarchMadness.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class coach : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Coach", "TeamId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Coach", "TeamId");
        }
    }
}
