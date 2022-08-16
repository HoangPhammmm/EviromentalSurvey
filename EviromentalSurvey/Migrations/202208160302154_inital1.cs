namespace EviromentalSurvey.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inital1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Class", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "Gender", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "Address", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "Rollnumber", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Rollnumber");
            DropColumn("dbo.AspNetUsers", "Address");
            DropColumn("dbo.AspNetUsers", "Gender");
            DropColumn("dbo.AspNetUsers", "Class");
        }
    }
}
