namespace Web_App_BioWell.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class data4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HealthDatas", "PatientId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.HealthDatas", "PatientId");
        }
    }
}
