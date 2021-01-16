namespace WebApp.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class IsDeletedOnBaseEntity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Laptops", "IsDeleted", c => c.Boolean(nullable: false));
        }

        public override void Down()
        {
            DropColumn("dbo.Laptops", "IsDeleted");
        }
    }
}