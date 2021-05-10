namespace SoundLabSocial.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixedTableRelationships : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PersonalAudio",
                c => new
                    {
                        PersonalAudioId = c.Int(nullable: false, identity: true),
                        Id = c.String(nullable: false, maxLength: 128),
                        AudioName = c.String(nullable: false),
                        AudioMessage = c.String(),
                        CreatedUTC = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUTC = c.DateTimeOffset(precision: 7),
                        PlaylistId = c.Int(),
                    })
                .PrimaryKey(t => t.PersonalAudioId)
                .ForeignKey("dbo.ApplicationUser", t => t.Id, cascadeDelete: true)
                .ForeignKey("dbo.Playlist", t => t.PlaylistId)
                .Index(t => t.Id)
                .Index(t => t.PlaylistId);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                        IdentityRole_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id);
            
            CreateTable(
                "dbo.Playlist",
                c => new
                    {
                        PlaylistId = c.Int(nullable: false, identity: true),
                        PlaylistName = c.String(nullable: false),
                        Id = c.String(nullable: false, maxLength: 128),
                        CreatedUTC = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUTC = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.PlaylistId)
                .ForeignKey("dbo.ApplicationUser", t => t.Id, cascadeDelete: true)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Song",
                c => new
                    {
                        SongId = c.Int(nullable: false, identity: true),
                        Id = c.String(nullable: false, maxLength: 128),
                        SongName = c.String(nullable: false),
                        SongArtist = c.String(nullable: false),
                        SongAlbum = c.String(),
                        ReleaseYear = c.String(),
                        CreatedUTC = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUTC = c.DateTimeOffset(precision: 7),
                        PlaylistId = c.Int(),
                    })
                .PrimaryKey(t => t.SongId)
                .ForeignKey("dbo.ApplicationUser", t => t.Id, cascadeDelete: true)
                .ForeignKey("dbo.Playlist", t => t.PlaylistId)
                .Index(t => t.Id)
                .Index(t => t.PlaylistId);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.PersonalAudio", "PlaylistId", "dbo.Playlist");
            DropForeignKey("dbo.Song", "PlaylistId", "dbo.Playlist");
            DropForeignKey("dbo.Song", "Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.Playlist", "Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.PersonalAudio", "Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropIndex("dbo.Song", new[] { "PlaylistId" });
            DropIndex("dbo.Song", new[] { "Id" });
            DropIndex("dbo.Playlist", new[] { "Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.PersonalAudio", new[] { "PlaylistId" });
            DropIndex("dbo.PersonalAudio", new[] { "Id" });
            DropTable("dbo.IdentityRole");
            DropTable("dbo.Song");
            DropTable("dbo.Playlist");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.PersonalAudio");
        }
    }
}
