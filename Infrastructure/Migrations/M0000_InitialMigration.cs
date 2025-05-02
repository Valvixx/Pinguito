using FluentMigrator;

namespace Infrastructure.Migrations;

[Migration(1)]
public class M0000_InitialMigration: Migration
{
    public override void Up()
    {
        Execute.Sql("create type advert_status as enum ('Active', 'Archive')");
        Create.Table("adverts")
            .WithColumn("id").AsGuid().PrimaryKey().WithDefault(SystemMethods.NewGuid)
            .WithColumn("title").AsString().NotNullable()
            .WithColumn("description").AsString().NotNullable()
            .WithColumn("price").AsDecimal().NotNullable()
            .WithColumn("creation_datetime").AsDateTime().NotNullable()
            .WithColumn("status").AsCustom("advert_status").NotNullable().WithDefaultValue("Active")
            .WithColumn("user_id").AsGuid().NotNullable()
            .WithColumn("category").AsGuid().NotNullable();
        
        Create.Table("advert_images")
            .WithColumn("id").AsGuid().PrimaryKey().WithDefault(SystemMethods.NewGuid)
            .WithColumn("advert_id").AsGuid().NotNullable()
            .WithColumn("reference").AsString().NotNullable();
        
        Create.Table("categories")
            .WithColumn("id").AsGuid().PrimaryKey().WithDefault(SystemMethods.NewGuid)
            .WithColumn("name").AsString(255).Unique().NotNullable()
            .WithColumn("parent_id").AsGuid().Nullable();
        
        
        Create.ForeignKey()
            .FromTable("adverts").ForeignColumn("category")
            .ToTable("categories").PrimaryColumn("id");
        
        Create.ForeignKey()
            .FromTable("advert_images").ForeignColumn("advert_id")
            .ToTable("adverts").PrimaryColumn("id");
        
        Create.ForeignKey("fk_categories_parent")
            .FromTable("categories").ForeignColumn("parent_id")
            .ToTable("categories").PrimaryColumn("id");
    }

    public override void Down()
    {
        Delete.Table("adverts");
        Delete.Table("advert_images");
        Delete.Table("categories");
    }
}