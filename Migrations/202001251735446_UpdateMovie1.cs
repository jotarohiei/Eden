namespace Eden.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMovie1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movies", "Genre", c => c.String(nullable: false, maxLength: 250));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "Genre", c => c.String(nullable: false));
        }
    }
}
