namespace PrsEf.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initialization : DbMigration
    {
        public override void Up() {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true), //identity: true means it must be unique -- assumes that Id is primary key
                        Username = c.String(), //when this creates the string the varchar length is max
                        Password = c.String(),
                        Firstname = c.String(),
                        Lastname = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                        IsReviewer = c.Boolean(nullable: false),
                        IsAdmin = c.Boolean(nullable: false),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id); //setting Id as primary key
        }
        
        public override void Down() {
            DropTable("dbo.Users");
        }
    }
}
