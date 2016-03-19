namespace PollInTheAir.Domain.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class CustomMigration : DbMigration
    {
        public override void Up()
        {
            // CASCADE ON DELETE FOR Question X MultipleChoicesQuestion
            this.DropForeignKey("dbo.MultipleChoicesQuestion", "FK_dbo.MultipleChoicesQuestion_dbo.Question_Id");
            this.AddForeignKey("dbo.MultipleChoicesQuestion", "Id", "dbo.Question", "Id", true, "FK_dbo.MultipleChoicesQuestion_dbo.Question_Id");

            // CASCADE ON DELETE FOR MultipleChoicesQuestion X Choices
            this.DropForeignKey("dbo.Choice", "FK_dbo.Choice_dbo.MultipleChoicesQuestion_MultipleChoicesQuestion_Id");
            this.AddForeignKey("dbo.Choice", "MultipleChoicesQuestion_Id", "dbo.MultipleChoicesQuestion", "Id", true, "FK_dbo.Choice_dbo.MultipleChoicesQuestion_MultipleChoicesQuestion_Id");

            // CASCADE ON DELETE FOR QuestionAnswer X MultipleChoicesAnswer
            // this.DropForeignKey("dbo.MultipleChoicesAnswer", "FK_dbo.MultipleChoicesAnswer_dbo.QuestionAnswer_Id");
            // this.AddForeignKey("dbo.MultipleChoicesAnswer", "Id", "dbo.QuestionAnswer", "Id", true, "FK_dbo.MultipleChoicesAnswer_dbo.QuestionAnswer_Id");

            // CASCADE ON DELETE FOR QuestionAnswer X FreeTextAnswer
            this.DropForeignKey("dbo.FreeTextAnswer", "FK_dbo.FreeTextAnswer_dbo.QuestionAnswer_Id");
            this.AddForeignKey("dbo.FreeTextAnswer", "Id", "dbo.QuestionAnswer", "Id", true, "FK_dbo.FreeTextAnswer_dbo.QuestionAnswer_Id");
        }

        public override void Down()
        {
        }
    }
}
