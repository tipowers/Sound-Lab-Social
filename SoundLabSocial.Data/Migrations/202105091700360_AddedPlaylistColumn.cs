namespace SoundLabSocial.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPlaylistColumn : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SongPlaylist", "Song_SongId", "dbo.Song");
            DropForeignKey("dbo.SongPlaylist", "Playlist_PlaylistId", "dbo.Playlist");
            DropIndex("dbo.SongPlaylist", new[] { "Song_SongId" });
            DropIndex("dbo.SongPlaylist", new[] { "Playlist_PlaylistId" });
            AddColumn("dbo.Song", "PlaylistId", c => c.Int());
            CreateIndex("dbo.Song", "PlaylistId");
            AddForeignKey("dbo.Song", "PlaylistId", "dbo.Playlist", "PlaylistId");
            DropTable("dbo.SongPlaylist");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.SongPlaylist",
                c => new
                    {
                        Song_SongId = c.Int(nullable: false),
                        Playlist_PlaylistId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Song_SongId, t.Playlist_PlaylistId });
            
            DropForeignKey("dbo.Song", "PlaylistId", "dbo.Playlist");
            DropIndex("dbo.Song", new[] { "PlaylistId" });
            DropColumn("dbo.Song", "PlaylistId");
            CreateIndex("dbo.SongPlaylist", "Playlist_PlaylistId");
            CreateIndex("dbo.SongPlaylist", "Song_SongId");
            AddForeignKey("dbo.SongPlaylist", "Playlist_PlaylistId", "dbo.Playlist", "PlaylistId", cascadeDelete: true);
            AddForeignKey("dbo.SongPlaylist", "Song_SongId", "dbo.Song", "SongId", cascadeDelete: true);
        }
    }
}
