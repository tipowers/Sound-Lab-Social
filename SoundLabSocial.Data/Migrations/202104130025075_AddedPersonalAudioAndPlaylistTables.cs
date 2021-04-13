namespace SoundLabSocial.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPersonalAudioAndPlaylistTables : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Song", "SongAlbum", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Song", "SongAlbum", c => c.String(nullable: false));
        }
    }
}
