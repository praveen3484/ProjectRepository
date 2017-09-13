namespace Contrucks.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NullableInt : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.NewJobPosts", "TruckTypeId", "dbo.TruckTypes");
            DropForeignKey("dbo.NewJobPosts", "LoadTypeId", "dbo.LoadTypes");
            DropIndex("dbo.NewJobPosts", new[] { "LoadTypeId" });
            DropIndex("dbo.NewJobPosts", new[] { "TruckTypeId" });
            AlterColumn("dbo.NewJobPosts", "LoadTypeId", c => c.Int());
            AlterColumn("dbo.NewJobPosts", "TruckTypeId", c => c.Int());
            CreateIndex("dbo.NewJobPosts", "LoadTypeId");
            CreateIndex("dbo.NewJobPosts", "TruckTypeId");
            AddForeignKey("dbo.NewJobPosts", "TruckTypeId", "dbo.TruckTypes", "TruckTypeId");
            AddForeignKey("dbo.NewJobPosts", "LoadTypeId", "dbo.LoadTypes", "LoadTypeId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.NewJobPosts", "LoadTypeId", "dbo.LoadTypes");
            DropForeignKey("dbo.NewJobPosts", "TruckTypeId", "dbo.TruckTypes");
            DropIndex("dbo.NewJobPosts", new[] { "TruckTypeId" });
            DropIndex("dbo.NewJobPosts", new[] { "LoadTypeId" });
            AlterColumn("dbo.NewJobPosts", "TruckTypeId", c => c.Int(nullable: false));
            AlterColumn("dbo.NewJobPosts", "LoadTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.NewJobPosts", "TruckTypeId");
            CreateIndex("dbo.NewJobPosts", "LoadTypeId");
            AddForeignKey("dbo.NewJobPosts", "LoadTypeId", "dbo.LoadTypes", "LoadTypeId", cascadeDelete: true);
            AddForeignKey("dbo.NewJobPosts", "TruckTypeId", "dbo.TruckTypes", "TruckTypeId", cascadeDelete: true);
        }
    }
}
