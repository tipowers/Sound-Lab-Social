namespace SoundLabSocial.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPlayListNamePropertyToPlaylistTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Playlist", "PlaylistName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Playlist", "PlaylistName");
        }
    }
}
