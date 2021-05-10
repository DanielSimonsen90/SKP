namespace LoginDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MessageTableTimestamp : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "Timestamp", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "Timestamp");
        }
    }
}
