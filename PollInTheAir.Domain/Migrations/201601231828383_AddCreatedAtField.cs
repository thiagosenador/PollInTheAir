namespace PollInTheAir.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCreatedAtField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Polls", "CreatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Choices", "Text", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Choices", "Text", c => c.String(nullable: false));
            DropColumn("dbo.Polls", "CreatedAt");
        }
    }
}
