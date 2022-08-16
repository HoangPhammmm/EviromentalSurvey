namespace EviromentalSurvey.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inital : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contents",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        CreateContentEventBy = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 255),
                        Sections = c.String(nullable: false, maxLength: 255),
                        Detail = c.String(nullable: false, maxLength: 255),
                        EventId = c.Int(nullable: false),
                        RewardId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Events", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        ConfirmBy = c.Int(nullable: false),
                        StartDay = c.DateTime(nullable: false, storeType: "date"),
                        EndDay = c.DateTime(nullable: false, storeType: "date"),
                        Status = c.String(maxLength: 255),
                        ContentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FAQs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FQAEventBy = c.Int(nullable: false),
                        Question = c.String(maxLength: 255),
                        Answer = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserEvents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateOfJoining = c.DateTime(nullable: false),
                        UserId = c.String(maxLength: 128),
                        EventId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Events", t => t.EventId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.EventId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Url = c.String(),
                        ContentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Contents", t => t.ContentId, cascadeDelete: true)
                .Index(t => t.ContentId);
            
            CreateTable(
                "dbo.Rewards",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Point = c.Int(nullable: false),
                        RewardName = c.String(nullable: false, maxLength: 50),
                        RewardContent = c.Int(nullable: false),
                        ContentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Contents", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.EventFAQs",
                c => new
                    {
                        EventId = c.Int(nullable: false),
                        FAQId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.EventId, t.FAQId })
                .ForeignKey("dbo.Events", t => t.EventId, cascadeDelete: true)
                .ForeignKey("dbo.FAQs", t => t.FAQId, cascadeDelete: true)
                .Index(t => t.EventId)
                .Index(t => t.FAQId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Rewards", "Id", "dbo.Contents");
            DropForeignKey("dbo.Images", "ContentId", "dbo.Contents");
            DropForeignKey("dbo.UserEvents", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserEvents", "EventId", "dbo.Events");
            DropForeignKey("dbo.EventFAQs", "FAQId", "dbo.FAQs");
            DropForeignKey("dbo.EventFAQs", "EventId", "dbo.Events");
            DropForeignKey("dbo.Contents", "Id", "dbo.Events");
            DropIndex("dbo.EventFAQs", new[] { "FAQId" });
            DropIndex("dbo.EventFAQs", new[] { "EventId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Rewards", new[] { "Id" });
            DropIndex("dbo.Images", new[] { "ContentId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.UserEvents", new[] { "EventId" });
            DropIndex("dbo.UserEvents", new[] { "UserId" });
            DropIndex("dbo.Contents", new[] { "Id" });
            DropTable("dbo.EventFAQs");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Rewards");
            DropTable("dbo.Images");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.UserEvents");
            DropTable("dbo.FAQs");
            DropTable("dbo.Events");
            DropTable("dbo.Contents");
        }
    }
}
