namespace AspNetMVC5Demo.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTask : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AbortTask", "From", c => c.Int(nullable: false));
            AddColumn("dbo.AbortTask", "To", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AbortTask", "To");
            DropColumn("dbo.AbortTask", "From");
        }
    }
}
