namespace Contrucks.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatingNewJobPosts_Table : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Balances",
                c => new
                    {
                        BalanceId = c.Int(nullable: false, identity: true),
                        UserTableId = c.Int(nullable: false),
                        Amount = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(maxLength: 255),
                        ModifiedBy = c.String(maxLength: 255),
                        ModifiedDate = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                        DeletedBy = c.String(maxLength: 255),
                        DeletedDate = c.DateTime(nullable: false),
                        UserTables_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.BalanceId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserTables_Id)
                .Index(t => t.UserTables_Id);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        CityId = c.Int(nullable: false, identity: true),
                        StateId = c.Int(nullable: false),
                        CityName = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        ModifiedDate = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                        Deleted = c.String(),
                        DeletedBy = c.String(),
                        DeletedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CityId)
                .ForeignKey("dbo.States", t => t.StateId, cascadeDelete: true)
                .Index(t => t.StateId);
            
            CreateTable(
                "dbo.Contractors",
                c => new
                    {
                        ContractorId = c.Int(nullable: false, identity: true),
                        UserTableId = c.Int(nullable: false),
                        StateId = c.Int(nullable: false),
                        CityId = c.Int(nullable: false),
                        ContractorName = c.String(nullable: false, maxLength: 255),
                        ContractorAge = c.Int(nullable: false),
                        ContractorPhone = c.String(nullable: false, maxLength: 15),
                        IsActive = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        ModifiedDate = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                        Deleted = c.String(),
                        DeletedBy = c.String(),
                        DeletedDate = c.DateTime(nullable: false),
                        UserTables_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ContractorId)
                .ForeignKey("dbo.States", t => t.StateId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserTables_Id)
                .ForeignKey("dbo.Cities", t => t.CityId)
                .Index(t => t.StateId)
                .Index(t => t.CityId)
                .Index(t => t.UserTables_Id);
            
            CreateTable(
                "dbo.JobDurations",
                c => new
                    {
                        JobDurationId = c.Int(nullable: false, identity: true),
                        ContractorId = c.Int(nullable: false),
                        JobStartTime = c.DateTime(nullable: false),
                        JobStopTime = c.DateTime(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(maxLength: 255),
                        ModifiedBy = c.String(maxLength: 255),
                        ModifiedDate = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                        DeletedBy = c.String(maxLength: 255),
                        DeletedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.JobDurationId)
                .ForeignKey("dbo.Contractors", t => t.ContractorId, cascadeDelete: true)
                .Index(t => t.ContractorId);
            
            CreateTable(
                "dbo.NewJobPosts",
                c => new
                    {
                        JobId = c.Int(nullable: false, identity: true),
                        ContractorId = c.Int(nullable: false),
                        LoadTypeId = c.Int(nullable: false),
                        TruckTypeId = c.Int(nullable: false),
                        distance = c.Int(nullable: false),
                        JobTitle = c.String(nullable: false, maxLength: 255),
                        JobDescription = c.String(nullable: false, maxLength: 3000),
                        JobStartDate = c.DateTime(nullable: false),
                        JobEndDate = c.DateTime(),
                        EstimatedTime = c.Int(nullable: false),
                        SourceAddress = c.String(nullable: false, maxLength: 500),
                        DestinationAddress = c.String(nullable: false, maxLength: 500),
                        LoadWeight = c.Int(nullable: false),
                        Budget = c.Int(nullable: false),
                        PostedDate = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        ModifiedDate = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                        Deleted = c.String(),
                        DeletedBy = c.String(),
                        DeletedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.JobId)
                .ForeignKey("dbo.Contractors", t => t.ContractorId, cascadeDelete: true)
                .ForeignKey("dbo.LoadTypes", t => t.LoadTypeId, cascadeDelete: true)
                .ForeignKey("dbo.TruckTypes", t => t.TruckTypeId, cascadeDelete: true)
                .Index(t => t.ContractorId)
                .Index(t => t.LoadTypeId)
                .Index(t => t.TruckTypeId);
            
            CreateTable(
                "dbo.JobApplications",
                c => new
                    {
                        JobApplicationId = c.Int(nullable: false, identity: true),
                        TruckerId = c.Int(nullable: false),
                        JobId = c.Int(nullable: false),
                        CoverLetter = c.String(nullable: false, maxLength: 3000),
                        AskingPrice = c.Long(nullable: false),
                        TimeRequired = c.DateTime(nullable: false),
                        JobApplicationStatus = c.String(),
                        IsJobAwarded = c.Boolean(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        ModifiedDate = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                        Deleted = c.String(),
                        DeletedBy = c.String(),
                        DeletedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.JobApplicationId)
                .ForeignKey("dbo.NewJobPosts", t => t.JobId, cascadeDelete: true)
                .ForeignKey("dbo.Truckers", t => t.TruckerId, cascadeDelete: true)
                .Index(t => t.TruckerId)
                .Index(t => t.JobId);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        MessageId = c.Int(nullable: false, identity: true),
                        JobApplicationId = c.Int(nullable: false),
                        SenderName = c.String(nullable: false, maxLength: 255),
                        MessageSubject = c.String(maxLength: 300),
                        MessageBody = c.String(maxLength: 3000),
                        MessageDate = c.DateTime(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(maxLength: 255),
                        ModifiedBy = c.String(maxLength: 255),
                        ModifiedDate = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                        DeletedBy = c.String(),
                        DeletedDate = c.DateTime(nullable: false),
                        Truckers_TruckerId = c.Int(),
                    })
                .PrimaryKey(t => t.MessageId)
                .ForeignKey("dbo.JobApplications", t => t.JobApplicationId, cascadeDelete: true)
                .ForeignKey("dbo.Truckers", t => t.Truckers_TruckerId)
                .Index(t => t.JobApplicationId)
                .Index(t => t.Truckers_TruckerId);
            
            CreateTable(
                "dbo.Truckers",
                c => new
                    {
                        TruckerId = c.Int(nullable: false, identity: true),
                        UserTableId = c.Int(nullable: false),
                        StateId = c.Int(nullable: false),
                        CityId = c.Int(nullable: false),
                        TruckerName = c.String(nullable: false, maxLength: 255),
                        TruckerAge = c.Int(nullable: false),
                        TruckerLicensePlate = c.String(nullable: false, maxLength: 20),
                        TruckerPhone = c.String(nullable: false, maxLength: 15),
                        IsActive = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        ModifiedDate = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                        Deleted = c.String(),
                        DeletedBy = c.String(),
                        DeletedDate = c.DateTime(nullable: false),
                        UserTable_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.TruckerId)
                .ForeignKey("dbo.States", t => t.StateId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserTable_Id)
                .ForeignKey("dbo.Cities", t => t.CityId)
                .Index(t => t.StateId)
                .Index(t => t.CityId)
                .Index(t => t.UserTable_Id);
            
            CreateTable(
                "dbo.States",
                c => new
                    {
                        StateId = c.Int(nullable: false, identity: true),
                        StateName = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        ModifiedDate = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                        Deleted = c.String(),
                        DeletedBy = c.String(),
                        DeletedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.StateId);
            
            CreateTable(
                "dbo.TruckerDetails",
                c => new
                    {
                        TruckId = c.Int(nullable: false, identity: true),
                        TruckerId = c.Int(nullable: false),
                        TruckTypeId = c.Int(nullable: false),
                        TruckNumber = c.String(nullable: false, maxLength: 255),
                        TruckMileage = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MaximumWeightBearable = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NumberOfWheels = c.Int(nullable: false),
                        TruckBoughtIn = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        ModifiedDate = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                        Deleted = c.String(),
                        DeletedBy = c.String(),
                        DeletedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.TruckId)
                .ForeignKey("dbo.Truckers", t => t.TruckerId, cascadeDelete: true)
                .ForeignKey("dbo.TruckTypes", t => t.TruckTypeId, cascadeDelete: true)
                .Index(t => t.TruckerId)
                .Index(t => t.TruckTypeId);
            
            CreateTable(
                "dbo.TruckTypes",
                c => new
                    {
                        TruckTypeId = c.Int(nullable: false, identity: true),
                        Trucktype = c.String(nullable: false, maxLength: 255),
                        IsActive = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        ModifiedDate = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                        Deleted = c.String(),
                        DeletedBy = c.String(),
                        DeletedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.TruckTypeId);
            
            CreateTable(
                "dbo.LoadTypes",
                c => new
                    {
                        LoadTypeId = c.Int(nullable: false, identity: true),
                        IsActive = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        ModifiedDate = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                        Deleted = c.String(),
                        DeletedBy = c.String(),
                        DeletedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.LoadTypeId);
            
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        TransactionId = c.Int(nullable: false, identity: true),
                        ContractorId = c.Int(nullable: false),
                        TruckerId = c.Int(nullable: false),
                        TransactionStatus = c.String(maxLength: 15),
                        IsActive = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        ModifiedDate = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                        Deleted = c.String(),
                        DeletedBy = c.String(),
                        DeletedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.TransactionId)
                .ForeignKey("dbo.Contractors", t => t.ContractorId, cascadeDelete: true)
                .ForeignKey("dbo.Truckers", t => t.TruckerId, cascadeDelete: true)
                .Index(t => t.ContractorId)
                .Index(t => t.TruckerId);
            
            CreateTable(
                "dbo.Ratings",
                c => new
                    {
                        RatingId = c.Int(nullable: false, identity: true),
                        ContractorId = c.Int(nullable: false),
                        TruckerId = c.Int(nullable: false),
                        Rating = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsActive = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        ModifiedDate = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                        Deleted = c.String(),
                        DeletedBy = c.String(),
                        DeletedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.RatingId)
                .ForeignKey("dbo.Contractors", t => t.ContractorId, cascadeDelete: true)
                .ForeignKey("dbo.Truckers", t => t.TruckerId, cascadeDelete: true)
                .Index(t => t.ContractorId)
                .Index(t => t.TruckerId);
            
            AddColumn("dbo.AspNetUsers", "UserTableId", c => c.Int());
            DropColumn("dbo.AspNetUsers", "PK_UserTableId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "PK_UserTableId", c => c.Int());
            DropForeignKey("dbo.Ratings", "TruckerId", "dbo.Truckers");
            DropForeignKey("dbo.Ratings", "ContractorId", "dbo.Contractors");
            DropForeignKey("dbo.Truckers", "CityId", "dbo.Cities");
            DropForeignKey("dbo.Contractors", "CityId", "dbo.Cities");
            DropForeignKey("dbo.Contractors", "UserTables_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Transactions", "TruckerId", "dbo.Truckers");
            DropForeignKey("dbo.Transactions", "ContractorId", "dbo.Contractors");
            DropForeignKey("dbo.NewJobPosts", "TruckTypeId", "dbo.TruckTypes");
            DropForeignKey("dbo.NewJobPosts", "LoadTypeId", "dbo.LoadTypes");
            DropForeignKey("dbo.JobApplications", "TruckerId", "dbo.Truckers");
            DropForeignKey("dbo.Truckers", "UserTable_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.TruckerDetails", "TruckTypeId", "dbo.TruckTypes");
            DropForeignKey("dbo.TruckerDetails", "TruckerId", "dbo.Truckers");
            DropForeignKey("dbo.Truckers", "StateId", "dbo.States");
            DropForeignKey("dbo.Contractors", "StateId", "dbo.States");
            DropForeignKey("dbo.Cities", "StateId", "dbo.States");
            DropForeignKey("dbo.Messages", "Truckers_TruckerId", "dbo.Truckers");
            DropForeignKey("dbo.JobApplications", "JobId", "dbo.NewJobPosts");
            DropForeignKey("dbo.Messages", "JobApplicationId", "dbo.JobApplications");
            DropForeignKey("dbo.NewJobPosts", "ContractorId", "dbo.Contractors");
            DropForeignKey("dbo.JobDurations", "ContractorId", "dbo.Contractors");
            DropForeignKey("dbo.Balances", "UserTables_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Ratings", new[] { "TruckerId" });
            DropIndex("dbo.Ratings", new[] { "ContractorId" });
            DropIndex("dbo.Transactions", new[] { "TruckerId" });
            DropIndex("dbo.Transactions", new[] { "ContractorId" });
            DropIndex("dbo.TruckerDetails", new[] { "TruckTypeId" });
            DropIndex("dbo.TruckerDetails", new[] { "TruckerId" });
            DropIndex("dbo.Truckers", new[] { "UserTable_Id" });
            DropIndex("dbo.Truckers", new[] { "CityId" });
            DropIndex("dbo.Truckers", new[] { "StateId" });
            DropIndex("dbo.Messages", new[] { "Truckers_TruckerId" });
            DropIndex("dbo.Messages", new[] { "JobApplicationId" });
            DropIndex("dbo.JobApplications", new[] { "JobId" });
            DropIndex("dbo.JobApplications", new[] { "TruckerId" });
            DropIndex("dbo.NewJobPosts", new[] { "TruckTypeId" });
            DropIndex("dbo.NewJobPosts", new[] { "LoadTypeId" });
            DropIndex("dbo.NewJobPosts", new[] { "ContractorId" });
            DropIndex("dbo.JobDurations", new[] { "ContractorId" });
            DropIndex("dbo.Contractors", new[] { "UserTables_Id" });
            DropIndex("dbo.Contractors", new[] { "CityId" });
            DropIndex("dbo.Contractors", new[] { "StateId" });
            DropIndex("dbo.Cities", new[] { "StateId" });
            DropIndex("dbo.Balances", new[] { "UserTables_Id" });
            DropColumn("dbo.AspNetUsers", "UserTableId");
            DropTable("dbo.Ratings");
            DropTable("dbo.Transactions");
            DropTable("dbo.LoadTypes");
            DropTable("dbo.TruckTypes");
            DropTable("dbo.TruckerDetails");
            DropTable("dbo.States");
            DropTable("dbo.Truckers");
            DropTable("dbo.Messages");
            DropTable("dbo.JobApplications");
            DropTable("dbo.NewJobPosts");
            DropTable("dbo.JobDurations");
            DropTable("dbo.Contractors");
            DropTable("dbo.Cities");
            DropTable("dbo.Balances");
        }
    }
}
