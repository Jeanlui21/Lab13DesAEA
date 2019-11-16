namespace Infraestructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "studentCode", c => c.Int(nullable: false));
            AddColumn("dbo.Students", "studentLastName", c => c.String());
            AddColumn("dbo.Students", "studentAddress", c => c.String(nullable: false));
            AddColumn("dbo.Students", "CreatedDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AddColumn("dbo.Students", "UpdatedDate", c => c.DateTime(precision: 7, storeType: "datetime2"));
            DropColumn("dbo.Students", "studendAddress");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "studendAddress", c => c.String(nullable: false));
            DropColumn("dbo.Students", "UpdatedDate");
            DropColumn("dbo.Students", "CreatedDate");
            DropColumn("dbo.Students", "studentAddress");
            DropColumn("dbo.Students", "studentLastName");
            DropColumn("dbo.Students", "studentCode");
        }
    }
}
