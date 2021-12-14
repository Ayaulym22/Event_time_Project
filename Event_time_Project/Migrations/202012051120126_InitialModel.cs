namespace Event_time_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Calendars",
                c => new
                    {
                        Calendar_id = c.Int(nullable: false, identity: true),
                        Month = c.Int(nullable: false),
                        Year = c.Int(nullable: false),
                        Day = c.Int(nullable: false),
                        Event_id = c.Int(),
                        Task_id = c.Int(),
                    })
                .PrimaryKey(t => t.Calendar_id)
                .ForeignKey("dbo.Events", t => t.Event_id)
                .ForeignKey("dbo.Tasks", t => t.Task_id)
                .Index(t => t.Event_id)
                .Index(t => t.Task_id);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        Event_id = c.Int(nullable: false, identity: true),
                        Event_name = c.String(),
                        Visited = c.Boolean(nullable: false),
                        Date = c.String(),
                        Time = c.String(),
                        Org_id = c.Int(),
                        Notify_id = c.Int(),
                    })
                .PrimaryKey(t => t.Event_id)
                .ForeignKey("dbo.Notifications", t => t.Notify_id)
                .ForeignKey("dbo.Organizations", t => t.Org_id)
                .Index(t => t.Org_id)
                .Index(t => t.Notify_id);
            
            CreateTable(
                "dbo.Notifications",
                c => new
                    {
                        Notify_Id = c.Int(nullable: false, identity: true),
                        Notify_date = c.String(),
                    })
                .PrimaryKey(t => t.Notify_Id);
            
            CreateTable(
                "dbo.Organizations",
                c => new
                    {
                        Org_id = c.Int(nullable: false, identity: true),
                        Org_name = c.String(),
                        Org_information = c.String(),
                        Address = c.String(),
                        Name_organizer = c.String(),
                    })
                .PrimaryKey(t => t.Org_id);
            
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        Task_id = c.Int(nullable: false, identity: true),
                        Task_name = c.String(),
                        Description = c.String(),
                        Deadline = c.String(),
                        Completed = c.Boolean(nullable: false),
                        Category_Id = c.Int(),
                        Notify_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Task_id)
                .ForeignKey("dbo.Category_Task", t => t.Category_Id)
                .ForeignKey("dbo.Notifications", t => t.Notify_Id)
                .Index(t => t.Category_Id)
                .Index(t => t.Notify_Id);
            
            CreateTable(
                "dbo.Category_Task",
                c => new
                    {
                        Category_Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Category_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        User_id = c.Int(nullable: false, identity: true),
                        User_name = c.String(),
                        Surname = c.String(),
                        Login = c.String(),
                        Password = c.String(),
                        Phone = c.String(),
                        Event_id = c.Int(),
                        Task_id = c.Int(),
                        Calendar_id = c.Int(),
                    })
                .PrimaryKey(t => t.User_id)
                .ForeignKey("dbo.Calendars", t => t.Calendar_id)
                .ForeignKey("dbo.Events", t => t.Event_id)
                .ForeignKey("dbo.Tasks", t => t.Task_id)
                .Index(t => t.Event_id)
                .Index(t => t.Task_id)
                .Index(t => t.Calendar_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "Task_id", "dbo.Tasks");
            DropForeignKey("dbo.Users", "Event_id", "dbo.Events");
            DropForeignKey("dbo.Users", "Calendar_id", "dbo.Calendars");
            DropForeignKey("dbo.Calendars", "Task_id", "dbo.Tasks");
            DropForeignKey("dbo.Tasks", "Notify_Id", "dbo.Notifications");
            DropForeignKey("dbo.Tasks", "Category_Id", "dbo.Category_Task");
            DropForeignKey("dbo.Calendars", "Event_id", "dbo.Events");
            DropForeignKey("dbo.Events", "Org_id", "dbo.Organizations");
            DropForeignKey("dbo.Events", "Notify_id", "dbo.Notifications");
            DropIndex("dbo.Users", new[] { "Calendar_id" });
            DropIndex("dbo.Users", new[] { "Task_id" });
            DropIndex("dbo.Users", new[] { "Event_id" });
            DropIndex("dbo.Tasks", new[] { "Notify_Id" });
            DropIndex("dbo.Tasks", new[] { "Category_Id" });
            DropIndex("dbo.Events", new[] { "Notify_id" });
            DropIndex("dbo.Events", new[] { "Org_id" });
            DropIndex("dbo.Calendars", new[] { "Task_id" });
            DropIndex("dbo.Calendars", new[] { "Event_id" });
            DropTable("dbo.Users");
            DropTable("dbo.Category_Task");
            DropTable("dbo.Tasks");
            DropTable("dbo.Organizations");
            DropTable("dbo.Notifications");
            DropTable("dbo.Events");
            DropTable("dbo.Calendars");
        }
    }
}
