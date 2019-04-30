using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SEO_optim_system.Migrations
{
    public partial class AddRequirements : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Requirements",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Keywords = table.Column<string>(nullable: true),
                    GooglePoz = table.Column<int>(nullable: false),
                    YandexPoz = table.Column<int>(nullable: false),
                    OptimImg = table.Column<bool>(nullable: false),
                    OptimText = table.Column<bool>(nullable: false),
                    OptimTag = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requirements", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Requirements");
        }
    }
}
