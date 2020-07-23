namespace ElevenNote.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Note", "CatId", "dbo.Category");
            DropIndex("dbo.Note", new[] { "CatId" });
            AlterColumn("dbo.Note", "CatId", c => c.Int());
            CreateIndex("dbo.Note", "CatId");
            AddForeignKey("dbo.Note", "CatId", "dbo.Category", "CategoryId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Note", "CatId", "dbo.Category");
            DropIndex("dbo.Note", new[] { "CatId" });
            AlterColumn("dbo.Note", "CatId", c => c.Int(nullable: false));
            CreateIndex("dbo.Note", "CatId");
            AddForeignKey("dbo.Note", "CatId", "dbo.Category", "CategoryId", cascadeDelete: true);
        }
    }
}
