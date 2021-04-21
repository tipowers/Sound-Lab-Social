namespace SoundLabSocial.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedReleaseYearToString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Song", "ReleaseYear", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Song", "ReleaseYear", c => c.DateTime(nullable: false));
        }
    }
}
