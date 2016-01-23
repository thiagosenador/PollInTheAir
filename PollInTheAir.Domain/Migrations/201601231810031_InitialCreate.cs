namespace PollInTheAir.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Polls",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 128),
                        ExpiresAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Statement = c.String(nullable: false, maxLength: 128),
                        CanSelectMultiple = c.Boolean(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        Poll_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Polls", t => t.Poll_Id)
                .Index(t => t.Poll_Id);
            
            CreateTable(
                "dbo.Choices",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Text = c.String(nullable: false),
                        MultipleChoicesQuestion_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Questions", t => t.MultipleChoicesQuestion_Id)
                .Index(t => t.MultipleChoicesQuestion_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Questions", "Poll_Id", "dbo.Polls");
            DropForeignKey("dbo.Choices", "MultipleChoicesQuestion_Id", "dbo.Questions");
            DropIndex("dbo.Choices", new[] { "MultipleChoicesQuestion_Id" });
            DropIndex("dbo.Questions", new[] { "Poll_Id" });
            DropTable("dbo.Choices");
            DropTable("dbo.Questions");
            DropTable("dbo.Polls");
        }
    }
}
