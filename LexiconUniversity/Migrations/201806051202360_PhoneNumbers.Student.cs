namespace LexiconUniversity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PhoneNumbersStudent : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PhoneNumbers", "Student_Id", "dbo.Students");
            DropIndex("dbo.PhoneNumbers", new[] { "Student_Id" });
            RenameColumn(table: "dbo.PhoneNumbers", name: "Student_Id", newName: "StudentId");
            AlterColumn("dbo.PhoneNumbers", "StudentId", c => c.Int(nullable: false));
            CreateIndex("dbo.PhoneNumbers", "StudentId");
            AddForeignKey("dbo.PhoneNumbers", "StudentId", "dbo.Students", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PhoneNumbers", "StudentId", "dbo.Students");
            DropIndex("dbo.PhoneNumbers", new[] { "StudentId" });
            AlterColumn("dbo.PhoneNumbers", "StudentId", c => c.Int());
            RenameColumn(table: "dbo.PhoneNumbers", name: "StudentId", newName: "Student_Id");
            CreateIndex("dbo.PhoneNumbers", "Student_Id");
            AddForeignKey("dbo.PhoneNumbers", "Student_Id", "dbo.Students", "Id");
        }
    }
}
