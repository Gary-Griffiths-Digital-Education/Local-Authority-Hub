using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Persistence.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeviceCodes",
                columns: table => new
                {
                    UserCode = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DeviceCode = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    SubjectId = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    SessionId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ClientId = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Expiration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Data = table.Column<string>(type: "nvarchar(max)", maxLength: 50000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceCodes", x => x.UserCode);
                });

            migrationBuilder.CreateTable(
                name: "Keys",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Version = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Use = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Algorithm = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsX509Certificate = table.Column<bool>(type: "bit", nullable: false),
                    DataProtected = table.Column<bool>(type: "bit", nullable: false),
                    Data = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Keys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OpenReferralLocations",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpenReferralLocations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OpenReferralOrganisations",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Uri = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpenReferralOrganisations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OpenReferralParents",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Vocabulary = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpenReferralParents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersistedGrants",
                columns: table => new
                {
                    Key = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SubjectId = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    SessionId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ClientId = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Expiration = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ConsumedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Data = table.Column<string>(type: "nvarchar(max)", maxLength: 50000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersistedGrants", x => x.Key);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Accessibility_For_Disabilities",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Accessibility = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OpenReferralLocationId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accessibility_For_Disabilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accessibility_For_Disabilities_OpenReferralLocations_OpenReferralLocationId",
                        column: x => x.OpenReferralLocationId,
                        principalTable: "OpenReferralLocations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OpenReferralPhysical_Addresses",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Address_1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Postal_code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State_province = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OpenReferralLocationId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpenReferralPhysical_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OpenReferralPhysical_Addresses_OpenReferralLocations_OpenReferralLocationId",
                        column: x => x.OpenReferralLocationId,
                        principalTable: "OpenReferralLocations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OpenReferralServices",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OpenReferralOrganisationId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Accreditations = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Assured_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Attending_access = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Attending_type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deliverable_type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fees = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpenReferralServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OpenReferralServices_OpenReferralOrganisations_OpenReferralOrganisationId",
                        column: x => x.OpenReferralOrganisationId,
                        principalTable: "OpenReferralOrganisations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OpenReferralContacts",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    OpenReferralServiceId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpenReferralContacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OpenReferralContacts_OpenReferralServices_OpenReferralServiceId",
                        column: x => x.OpenReferralServiceId,
                        principalTable: "OpenReferralServices",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OpenReferralCost_Options",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Amount_description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LinkId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Option = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Valid_from = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Valid_to = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OpenReferralServiceId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpenReferralCost_Options", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OpenReferralCost_Options_OpenReferralServices_OpenReferralServiceId",
                        column: x => x.OpenReferralServiceId,
                        principalTable: "OpenReferralServices",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OpenReferralEligibilities",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OpenReferralServiceId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Eligibility = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LinkId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Maximum_age = table.Column<int>(type: "int", nullable: false),
                    Minimum_age = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpenReferralEligibilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OpenReferralEligibilities_OpenReferralServices_OpenReferralServiceId",
                        column: x => x.OpenReferralServiceId,
                        principalTable: "OpenReferralServices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OpenReferralFundings",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Source = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OpenReferralServiceId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpenReferralFundings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OpenReferralFundings_OpenReferralServices_OpenReferralServiceId",
                        column: x => x.OpenReferralServiceId,
                        principalTable: "OpenReferralServices",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OpenReferralLanguages",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OpenReferralServiceId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpenReferralLanguages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OpenReferralLanguages_OpenReferralServices_OpenReferralServiceId",
                        column: x => x.OpenReferralServiceId,
                        principalTable: "OpenReferralServices",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OpenReferralReviews",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Score = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Widget = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OpenReferralOrganisationId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    OpenReferralServiceId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpenReferralReviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OpenReferralReviews_OpenReferralOrganisations_OpenReferralOrganisationId",
                        column: x => x.OpenReferralOrganisationId,
                        principalTable: "OpenReferralOrganisations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OpenReferralReviews_OpenReferralServices_OpenReferralServiceId",
                        column: x => x.OpenReferralServiceId,
                        principalTable: "OpenReferralServices",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OpenReferralService_Areas",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Service_area = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LinkId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Extent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Uri = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OpenReferralServiceId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpenReferralService_Areas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OpenReferralService_Areas_OpenReferralServices_OpenReferralServiceId",
                        column: x => x.OpenReferralServiceId,
                        principalTable: "OpenReferralServices",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OpenReferralServiceAtLocations",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LocationId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OpenReferralServiceId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpenReferralServiceAtLocations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OpenReferralServiceAtLocations_OpenReferralLocations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "OpenReferralLocations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OpenReferralServiceAtLocations_OpenReferralServices_OpenReferralServiceId",
                        column: x => x.OpenReferralServiceId,
                        principalTable: "OpenReferralServices",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OpenReferralServiceDeliveries",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ServiceDeliveryEx = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    OpenReferralServiceId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpenReferralServiceDeliveries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OpenReferralServiceDeliveries_OpenReferralServices_OpenReferralServiceId",
                        column: x => x.OpenReferralServiceId,
                        principalTable: "OpenReferralServices",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OpenReferralPhones",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OpenReferralContactId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpenReferralPhones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OpenReferralPhones_OpenReferralContacts_OpenReferralContactId",
                        column: x => x.OpenReferralContactId,
                        principalTable: "OpenReferralContacts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OpenReferralTaxonomies",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Vocabulary = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Parent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OpenReferralEligibilityId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpenReferralTaxonomies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OpenReferralTaxonomies_OpenReferralEligibilities_OpenReferralEligibilityId",
                        column: x => x.OpenReferralEligibilityId,
                        principalTable: "OpenReferralEligibilities",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OpenReferralHoliday_Schedules",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Closed = table.Column<bool>(type: "bit", nullable: false),
                    Closes_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Start_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    End_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Opens_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OpenReferralServiceAtLocationId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    OpenReferralServiceId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpenReferralHoliday_Schedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OpenReferralHoliday_Schedules_OpenReferralServiceAtLocations_OpenReferralServiceAtLocationId",
                        column: x => x.OpenReferralServiceAtLocationId,
                        principalTable: "OpenReferralServiceAtLocations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OpenReferralHoliday_Schedules_OpenReferralServices_OpenReferralServiceId",
                        column: x => x.OpenReferralServiceId,
                        principalTable: "OpenReferralServices",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OpenReferralRegular_Schedules",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Opens_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Closes_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Byday = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bymonthday = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dtstart = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Freq = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Interval = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Valid_from = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Valid_to = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OpenReferralServiceAtLocationId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    OpenReferralServiceId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpenReferralRegular_Schedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OpenReferralRegular_Schedules_OpenReferralServiceAtLocations_OpenReferralServiceAtLocationId",
                        column: x => x.OpenReferralServiceAtLocationId,
                        principalTable: "OpenReferralServiceAtLocations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OpenReferralRegular_Schedules_OpenReferralServices_OpenReferralServiceId",
                        column: x => x.OpenReferralServiceId,
                        principalTable: "OpenReferralServices",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OpenReferralLinktaxonomycollections",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Link_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Link_type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OpenReferralParentId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    OpenReferralTaxonomyId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpenReferralLinktaxonomycollections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OpenReferralLinktaxonomycollections_OpenReferralParents_OpenReferralParentId",
                        column: x => x.OpenReferralParentId,
                        principalTable: "OpenReferralParents",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OpenReferralLinktaxonomycollections_OpenReferralTaxonomies_OpenReferralTaxonomyId",
                        column: x => x.OpenReferralTaxonomyId,
                        principalTable: "OpenReferralTaxonomies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OpenReferralService_Taxonomies",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LinkId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaxonomyId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    OpenReferralParentId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    OpenReferralServiceId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpenReferralService_Taxonomies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OpenReferralService_Taxonomies_OpenReferralParents_OpenReferralParentId",
                        column: x => x.OpenReferralParentId,
                        principalTable: "OpenReferralParents",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OpenReferralService_Taxonomies_OpenReferralServices_OpenReferralServiceId",
                        column: x => x.OpenReferralServiceId,
                        principalTable: "OpenReferralServices",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OpenReferralService_Taxonomies_OpenReferralTaxonomies_TaxonomyId",
                        column: x => x.TaxonomyId,
                        principalTable: "OpenReferralTaxonomies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accessibility_For_Disabilities_OpenReferralLocationId",
                table: "Accessibility_For_Disabilities",
                column: "OpenReferralLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_DeviceCodes_DeviceCode",
                table: "DeviceCodes",
                column: "DeviceCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DeviceCodes_Expiration",
                table: "DeviceCodes",
                column: "Expiration");

            migrationBuilder.CreateIndex(
                name: "IX_Keys_Use",
                table: "Keys",
                column: "Use");

            migrationBuilder.CreateIndex(
                name: "IX_OpenReferralContacts_OpenReferralServiceId",
                table: "OpenReferralContacts",
                column: "OpenReferralServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_OpenReferralCost_Options_OpenReferralServiceId",
                table: "OpenReferralCost_Options",
                column: "OpenReferralServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_OpenReferralEligibilities_OpenReferralServiceId",
                table: "OpenReferralEligibilities",
                column: "OpenReferralServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_OpenReferralFundings_OpenReferralServiceId",
                table: "OpenReferralFundings",
                column: "OpenReferralServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_OpenReferralHoliday_Schedules_OpenReferralServiceAtLocationId",
                table: "OpenReferralHoliday_Schedules",
                column: "OpenReferralServiceAtLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_OpenReferralHoliday_Schedules_OpenReferralServiceId",
                table: "OpenReferralHoliday_Schedules",
                column: "OpenReferralServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_OpenReferralLanguages_OpenReferralServiceId",
                table: "OpenReferralLanguages",
                column: "OpenReferralServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_OpenReferralLinktaxonomycollections_OpenReferralParentId",
                table: "OpenReferralLinktaxonomycollections",
                column: "OpenReferralParentId");

            migrationBuilder.CreateIndex(
                name: "IX_OpenReferralLinktaxonomycollections_OpenReferralTaxonomyId",
                table: "OpenReferralLinktaxonomycollections",
                column: "OpenReferralTaxonomyId");

            migrationBuilder.CreateIndex(
                name: "IX_OpenReferralPhones_OpenReferralContactId",
                table: "OpenReferralPhones",
                column: "OpenReferralContactId");

            migrationBuilder.CreateIndex(
                name: "IX_OpenReferralPhysical_Addresses_OpenReferralLocationId",
                table: "OpenReferralPhysical_Addresses",
                column: "OpenReferralLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_OpenReferralRegular_Schedules_OpenReferralServiceAtLocationId",
                table: "OpenReferralRegular_Schedules",
                column: "OpenReferralServiceAtLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_OpenReferralRegular_Schedules_OpenReferralServiceId",
                table: "OpenReferralRegular_Schedules",
                column: "OpenReferralServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_OpenReferralReviews_OpenReferralOrganisationId",
                table: "OpenReferralReviews",
                column: "OpenReferralOrganisationId");

            migrationBuilder.CreateIndex(
                name: "IX_OpenReferralReviews_OpenReferralServiceId",
                table: "OpenReferralReviews",
                column: "OpenReferralServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_OpenReferralService_Areas_OpenReferralServiceId",
                table: "OpenReferralService_Areas",
                column: "OpenReferralServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_OpenReferralService_Taxonomies_OpenReferralParentId",
                table: "OpenReferralService_Taxonomies",
                column: "OpenReferralParentId");

            migrationBuilder.CreateIndex(
                name: "IX_OpenReferralService_Taxonomies_OpenReferralServiceId",
                table: "OpenReferralService_Taxonomies",
                column: "OpenReferralServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_OpenReferralService_Taxonomies_TaxonomyId",
                table: "OpenReferralService_Taxonomies",
                column: "TaxonomyId");

            migrationBuilder.CreateIndex(
                name: "IX_OpenReferralServiceAtLocations_LocationId",
                table: "OpenReferralServiceAtLocations",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_OpenReferralServiceAtLocations_OpenReferralServiceId",
                table: "OpenReferralServiceAtLocations",
                column: "OpenReferralServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_OpenReferralServiceDeliveries_OpenReferralServiceId",
                table: "OpenReferralServiceDeliveries",
                column: "OpenReferralServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_OpenReferralServices_OpenReferralOrganisationId",
                table: "OpenReferralServices",
                column: "OpenReferralOrganisationId");

            migrationBuilder.CreateIndex(
                name: "IX_OpenReferralTaxonomies_OpenReferralEligibilityId",
                table: "OpenReferralTaxonomies",
                column: "OpenReferralEligibilityId");

            migrationBuilder.CreateIndex(
                name: "IX_PersistedGrants_ConsumedTime",
                table: "PersistedGrants",
                column: "ConsumedTime");

            migrationBuilder.CreateIndex(
                name: "IX_PersistedGrants_Expiration",
                table: "PersistedGrants",
                column: "Expiration");

            migrationBuilder.CreateIndex(
                name: "IX_PersistedGrants_SubjectId_ClientId_Type",
                table: "PersistedGrants",
                columns: new[] { "SubjectId", "ClientId", "Type" });

            migrationBuilder.CreateIndex(
                name: "IX_PersistedGrants_SubjectId_SessionId_Type",
                table: "PersistedGrants",
                columns: new[] { "SubjectId", "SessionId", "Type" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accessibility_For_Disabilities");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "DeviceCodes");

            migrationBuilder.DropTable(
                name: "Keys");

            migrationBuilder.DropTable(
                name: "OpenReferralCost_Options");

            migrationBuilder.DropTable(
                name: "OpenReferralFundings");

            migrationBuilder.DropTable(
                name: "OpenReferralHoliday_Schedules");

            migrationBuilder.DropTable(
                name: "OpenReferralLanguages");

            migrationBuilder.DropTable(
                name: "OpenReferralLinktaxonomycollections");

            migrationBuilder.DropTable(
                name: "OpenReferralPhones");

            migrationBuilder.DropTable(
                name: "OpenReferralPhysical_Addresses");

            migrationBuilder.DropTable(
                name: "OpenReferralRegular_Schedules");

            migrationBuilder.DropTable(
                name: "OpenReferralReviews");

            migrationBuilder.DropTable(
                name: "OpenReferralService_Areas");

            migrationBuilder.DropTable(
                name: "OpenReferralService_Taxonomies");

            migrationBuilder.DropTable(
                name: "OpenReferralServiceDeliveries");

            migrationBuilder.DropTable(
                name: "PersistedGrants");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "OpenReferralContacts");

            migrationBuilder.DropTable(
                name: "OpenReferralServiceAtLocations");

            migrationBuilder.DropTable(
                name: "OpenReferralParents");

            migrationBuilder.DropTable(
                name: "OpenReferralTaxonomies");

            migrationBuilder.DropTable(
                name: "OpenReferralLocations");

            migrationBuilder.DropTable(
                name: "OpenReferralEligibilities");

            migrationBuilder.DropTable(
                name: "OpenReferralServices");

            migrationBuilder.DropTable(
                name: "OpenReferralOrganisations");
        }
    }
}
