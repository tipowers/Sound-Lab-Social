namespace SoundLabSocial.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ActualFinalizedDataModelsForNow : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Playlist", "PersonalAudioId", "dbo.PersonalAudio");
            DropIndex("dbo.Playlist", new[] { "PersonalAudioId" });
            AlterColumn("dbo.Playlist", "PersonalAudioId", c => c.Int());
            CreateIndex("dbo.Playlist", "PersonalAudioId");
            AddForeignKey("dbo.Playlist", "PersonalAudioId", "dbo.PersonalAudio", "AudioId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Playlist", "PersonalAudioId", "dbo.PersonalAudio");
            DropIndex("dbo.Playlist", new[] { "PersonalAudioId" });
            AlterColumn("dbo.Playlist", "PersonalAudioId", c => c.Int(nullable: false));
            CreateIndex("dbo.Playlist", "PersonalAudioId");
            AddForeignKey("dbo.Playlist", "PersonalAudioId", "dbo.PersonalAudio", "AudioId", cascadeDelete: true);
        }
    }
}
