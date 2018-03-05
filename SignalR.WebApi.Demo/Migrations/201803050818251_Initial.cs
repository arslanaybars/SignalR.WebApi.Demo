namespace SignalR.WebApi.Demo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Forms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 50, unicode: false),
                        Description = c.String(maxLength: 200),
                        Content = c.String(),
                        CreateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Age = c.Int(nullable: false),
                        IsAdmin = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserForms",
                c => new
                    {
                        User_Id = c.Int(nullable: false),
                        Form_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_Id, t.Form_Id })
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .ForeignKey("dbo.Forms", t => t.Form_Id, cascadeDelete: true)
                .Index(t => t.User_Id)
                .Index(t => t.Form_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserForms", "Form_Id", "dbo.Forms");
            DropForeignKey("dbo.UserForms", "User_Id", "dbo.Users");
            DropIndex("dbo.UserForms", new[] { "Form_Id" });
            DropIndex("dbo.UserForms", new[] { "User_Id" });
            DropTable("dbo.UserForms");
            DropTable("dbo.Users");
            DropTable("dbo.Forms");
        }
    }
}
