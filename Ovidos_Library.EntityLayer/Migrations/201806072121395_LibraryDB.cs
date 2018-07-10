namespace Ovidos_Library.EntityLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LibraryDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Book",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Publisher = c.String(maxLength: 50),
                        Author = c.String(maxLength: 50),
                        PublicationDate = c.Int(),
                        Language = c.String(maxLength: 50),
                        PrintLength = c.Int(),
                        ISBN = c.String(maxLength: 50),
                        BookStock_ID = c.Int(),
                        BookTransaction_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.BookStock", t => t.BookStock_ID)
                .ForeignKey("dbo.BookTransaction", t => t.BookTransaction_ID)
                .Index(t => t.BookStock_ID)
                .Index(t => t.BookTransaction_ID);
            
            CreateTable(
                "dbo.BookStock",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        BookID = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.BookTransaction",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        BookID = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                        DateOfReserved = c.DateTime(nullable: false),
                        ExpirationOfReserveDate = c.DateTime(nullable: false),
                        DateOfReturned = c.DateTime(),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Username = c.String(maxLength: 50),
                        Password = c.String(maxLength: 50),
                        BookTransaction_ID = c.Int(),
                        Log_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.BookTransaction", t => t.BookTransaction_ID)
                .ForeignKey("dbo.Log", t => t.Log_ID)
                .Index(t => t.BookTransaction_ID)
                .Index(t => t.Log_ID);
            
            CreateTable(
                "dbo.Log",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        TransactionDescription = c.String(maxLength: 250),
                        TransactionDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.User", "Log_ID", "dbo.Log");
            DropForeignKey("dbo.User", "BookTransaction_ID", "dbo.BookTransaction");
            DropForeignKey("dbo.Book", "BookTransaction_ID", "dbo.BookTransaction");
            DropForeignKey("dbo.Book", "BookStock_ID", "dbo.BookStock");
            DropIndex("dbo.User", new[] { "Log_ID" });
            DropIndex("dbo.User", new[] { "BookTransaction_ID" });
            DropIndex("dbo.Book", new[] { "BookTransaction_ID" });
            DropIndex("dbo.Book", new[] { "BookStock_ID" });
            DropTable("dbo.Log");
            DropTable("dbo.User");
            DropTable("dbo.BookTransaction");
            DropTable("dbo.BookStock");
            DropTable("dbo.Book");
        }
    }
}
