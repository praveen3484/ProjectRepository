namespace Contrucks.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initiallevel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Cities", "Deleted", c => c.String());
            AlterColumn("dbo.Contractors", "Deleted", c => c.String());
            AlterColumn("dbo.NewJobPosts", "CreatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.NewJobPosts", "Deleted", c => c.String());
            AlterColumn("dbo.JobApplications", "Deleted", c => c.String());
            AlterColumn("dbo.Truckers", "Deleted", c => c.String());
            AlterColumn("dbo.States", "Deleted", c => c.String());
            AlterColumn("dbo.TruckerDetails", "Deleted", c => c.String());
            AlterColumn("dbo.LoadTypes", "Deleted", c => c.String());
            AlterColumn("dbo.Transactions", "Deleted", c => c.String());
            AlterColumn("dbo.Ratings", "Deleted", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Ratings", "Deleted", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Transactions", "Deleted", c => c.Boolean(nullable: false));
            AlterColumn("dbo.LoadTypes", "Deleted", c => c.Boolean(nullable: false));
            AlterColumn("dbo.TruckerDetails", "Deleted", c => c.Boolean(nullable: false));
            AlterColumn("dbo.States", "Deleted", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Truckers", "Deleted", c => c.Boolean(nullable: false));
            AlterColumn("dbo.JobApplications", "Deleted", c => c.Boolean(nullable: false));
            AlterColumn("dbo.NewJobPosts", "Deleted", c => c.Boolean(nullable: false));
            AlterColumn("dbo.NewJobPosts", "CreatedDate", c => c.DateTime());
            AlterColumn("dbo.Contractors", "Deleted", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Cities", "Deleted", c => c.Boolean(nullable: false));
        }
    }
}
