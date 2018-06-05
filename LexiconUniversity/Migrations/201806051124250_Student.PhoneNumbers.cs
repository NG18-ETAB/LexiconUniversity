namespace LexiconUniversity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StudentPhoneNumbers : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PhoneNumbers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.String(),
                        Student_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Students", t => t.Student_Id)
                .Index(t => t.Student_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PhoneNumbers", "Student_Id", "dbo.Students");
            DropIndex("dbo.PhoneNumbers", new[] { "Student_Id" });
            DropTable("dbo.PhoneNumbers");
        }
    }
}
