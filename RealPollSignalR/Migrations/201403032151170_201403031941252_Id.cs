namespace RealPollSignalR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _201403031941252_Id : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Questions", "QuestionUniqueId", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Questions", "QuestionUniqueId");
        }
    }
}
