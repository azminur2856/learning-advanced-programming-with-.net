namespace APICRUDCF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStudentsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200, unicode: false),
                        Cgpa = c.Double(),
                    })
                .PrimaryKey(t => t.StudentId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Students");
        }
    }
}
