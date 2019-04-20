namespace Web_App_BioWell.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class data5 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.HealthDatas", "PatientId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.HealthDatas", "PatientId", c => c.Int(nullable: false));
        }
    }
}
