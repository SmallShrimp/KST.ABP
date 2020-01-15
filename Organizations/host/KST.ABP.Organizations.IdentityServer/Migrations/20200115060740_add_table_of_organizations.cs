using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KST.ABP.Organizations.Migrations
{
    public partial class add_table_of_organizations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KstOrganizationUnit",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    TenantId = table.Column<Guid>(nullable: true),
                    ParentId = table.Column<Guid>(nullable: true),
                    Code = table.Column<string>(maxLength: 95, nullable: false),
                    DisplayName = table.Column<string>(maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KstOrganizationUnit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KstOrganizationUnit_KstOrganizationUnit_ParentId",
                        column: x => x.ParentId,
                        principalTable: "KstOrganizationUnit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "KstOrganizationUnitRole",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    TenantId = table.Column<Guid>(nullable: true),
                    OrganizationUnitId = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KstOrganizationUnitRole", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KstUserOrganizationUnit",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    TenantId = table.Column<Guid>(nullable: true),
                    OrganizationUnitId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KstUserOrganizationUnit", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KstOrganizationUnit_Code",
                table: "KstOrganizationUnit",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_KstOrganizationUnit_ParentId",
                table: "KstOrganizationUnit",
                column: "ParentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KstOrganizationUnit");

            migrationBuilder.DropTable(
                name: "KstOrganizationUnitRole");

            migrationBuilder.DropTable(
                name: "KstUserOrganizationUnit");
        }
    }
}
