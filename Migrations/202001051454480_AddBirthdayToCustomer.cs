namespace Eden.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBirthdayToCustomer : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "Birthday", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "Birthday", c => c.Int());
        }
    }
}
