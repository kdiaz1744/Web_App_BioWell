namespace Web_App_BioWell.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class data3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HealthDatas",
                c => new
                    {
                        DataId = c.Int(nullable: false, identity: true),
                        DataDate = c.Double(nullable: false),
                        DataWeight = c.Double(nullable: false),
                        DataBmi = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.DataId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.HealthDatas");
        }
    }
}
