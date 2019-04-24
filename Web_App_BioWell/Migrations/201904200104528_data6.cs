namespace Web_App_BioWell.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class data6 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.HealthDatas", "DataDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.HealthDatas", "DataDate", c => c.Double(nullable: false));
        }
    }
}
