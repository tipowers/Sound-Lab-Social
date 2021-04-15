namespace SoundLabSocial.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FinalizedDataModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PersonalAudio",
                c => new
                    {
                        AudioId = c.Int(nullable: false, identity: true),
                        Id = c.String(nullable: false, maxLength: 128),
                        AudioName = c.String(nullable: false),
                        CreatedUTC = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUTC = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.AudioId)
                .ForeignKey("dbo.ApplicationUser", t => t.Id, cascadeDelete: true)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Playlist",
                c => new
                    {
                        PlaylistId = c.Int(nullable: false, identity: true),
                        Id = c.String(nullable: false, maxLength: 128),
                        PersonalAudioId = c.Int(nullable: false),
                        CreatedUTC = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUTC = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.PlaylistId)
                .ForeignKey("dbo.ApplicationUser", t => t.Id, cascadeDelete: true)
                .ForeignKey("dbo.PersonalAudio", t => t.PersonalAudioId, cascadeDelete: false)
                .Index(t => t.Id)
                .Index(t => t.PersonalAudioId);
            
            CreateTable(
                "dbo.SongPlaylist",
                c => new
                    {
                        Song_SongId = c.Int(nullable: false),
                        Playlist_PlaylistId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Song_SongId, t.Playlist_PlaylistId })
                .ForeignKey("dbo.Song", t => t.Song_SongId, cascadeDelete: true)
                .ForeignKey("dbo.Playlist", t => t.Playlist_PlaylistId, cascadeDelete: false)
                .Index(t => t.Song_SongId)
                .Index(t => t.Playlist_PlaylistId);
            
            AddColumn("dbo.Song", "Id", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Song", "Id");
            AddForeignKey("dbo.Song", "Id", "dbo.ApplicationUser", "Id", cascadeDelete: true);
            DropColumn("dbo.Song", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Song", "UserId", c => c.Int(nullable: false));
            DropForeignKey("dbo.SongPlaylist", "Playlist_PlaylistId", "dbo.Playlist");
            DropForeignKey("dbo.SongPlaylist", "Song_SongId", "dbo.Song");
            DropForeignKey("dbo.Song", "Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.Playlist", "PersonalAudioId", "dbo.PersonalAudio");
            DropForeignKey("dbo.Playlist", "Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.PersonalAudio", "Id", "dbo.ApplicationUser");
            DropIndex("dbo.SongPlaylist", new[] { "Playlist_PlaylistId" });
            DropIndex("dbo.SongPlaylist", new[] { "Song_SongId" });
            DropIndex("dbo.Song", new[] { "Id" });
            DropIndex("dbo.Playlist", new[] { "PersonalAudioId" });
            DropIndex("dbo.Playlist", new[] { "Id" });
            DropIndex("dbo.PersonalAudio", new[] { "Id" });
            DropColumn("dbo.Song", "Id");
            DropTable("dbo.SongPlaylist");
            DropTable("dbo.Playlist");
            DropTable("dbo.PersonalAudio");
        }
    }
}
