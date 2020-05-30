using Microsoft.EntityFrameworkCore.Migrations;

namespace kartzmax.Migrations {
    public partial class SeedFeatures : Migration {
        protected override void Up (MigrationBuilder migrationBuilder) {

            migrationBuilder.Sql ("INSERT INTO Features (Name) VALUES ('Feature 1')");
            migrationBuilder.Sql ("INSERT INTO Features (Name) VALUES ('Feature 2')");

            migrationBuilder.Sql ("INSERT INTO Features (Name) VALUES ('Feature 3')");

        }

        protected override void Down (MigrationBuilder migrationBuilder) {

                  migrationBuilder.Sql("DELETE FROM Features WHERE Name IN ('Feature1', 'Feature2', 'Feature3')");
        }
    }
}