namespace Blog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FeedbackCreated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Feedbacks", "Created", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Feedbacks", "Created");
        }
    }
}
