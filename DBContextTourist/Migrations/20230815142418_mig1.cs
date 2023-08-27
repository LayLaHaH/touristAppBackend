using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBContextTourist.Migrations
{
    public partial class mig1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Activity",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    price = table.Column<decimal>(type: "money", nullable: false),
                    startTime = table.Column<DateTime>(type: "date", nullable: false),
                    closeTime = table.Column<DateTime>(type: "date", nullable: false),
                    startingDay = table.Column<DateTime>(type: "date", nullable: true),
                    endingDay = table.Column<DateTime>(type: "date", nullable: true),
                    image = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activity", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(225)", maxLength: 225, nullable: false),
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
                    Id = table.Column<string>(type: "nvarchar(225)", maxLength: 225, nullable: false),
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
                name: "Governorate",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    picture = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Governorate", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TourCompany",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    contactNumber = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    address = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TourCompany", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(225)", nullable: false),
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
                    UserId = table.Column<string>(type: "nvarchar(225)", nullable: false),
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
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(225)", maxLength: 225, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(225)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(225)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(225)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(225)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                name: "City",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    picture = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    governerateID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.ID);
                    table.ForeignKey(
                        name: "FK_City_Governorate",
                        column: x => x.governerateID,
                        principalTable: "Governorate",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Tour",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: false),
                    daysNnights = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    cost = table.Column<decimal>(type: "money", nullable: false),
                    theme = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: false),
                    isPrivate = table.Column<bool>(type: "bit", nullable: false),
                    guidLanguage = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: false),
                    companyID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tour", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Tour_TourCompany",
                        column: x => x.companyID,
                        principalTable: "TourCompany",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Destination",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    address = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    theme = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    cityID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Destination", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Destination_City",
                        column: x => x.cityID,
                        principalTable: "City",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Hotel",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    contactNumber = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    url = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    address = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: false),
                    classStar = table.Column<int>(type: "int", nullable: false),
                    image = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    cityID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotel", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Hotel_City",
                        column: x => x.cityID,
                        principalTable: "City",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Market",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    image = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    cityID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Market", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Market_City",
                        column: x => x.cityID,
                        principalTable: "City",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Restaurant",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    contactNumber = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    url = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    address = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: false),
                    classStar = table.Column<int>(type: "int", nullable: false),
                    openingHour = table.Column<DateTime>(type: "date", nullable: false),
                    closingHour = table.Column<DateTime>(type: "date", nullable: false),
                    cuisine = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    image = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    cityID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurant", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Restaurant_City",
                        column: x => x.cityID,
                        principalTable: "City",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Excludes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    excludes = table.Column<string>(type: "text", nullable: false),
                    tourID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Excludes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Excludes_Tour",
                        column: x => x.tourID,
                        principalTable: "Tour",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Includes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    includes = table.Column<string>(type: "text", nullable: false),
                    tourID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Includes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Includes_Tour",
                        column: x => x.tourID,
                        principalTable: "Tour",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Itinerary",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    eachDayDescription = table.Column<string>(type: "text", nullable: false),
                    tourID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Itinerary", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Itinerary_Tour",
                        column: x => x.tourID,
                        principalTable: "Tour",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "tourHasActivities",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tourID = table.Column<int>(type: "int", nullable: false),
                    activityID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tourHasActivities", x => x.ID);
                    table.ForeignKey(
                        name: "FK_tourHasActivities_Activity",
                        column: x => x.activityID,
                        principalTable: "Activity",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_tourHasActivities_Tour",
                        column: x => x.tourID,
                        principalTable: "Tour",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "DestinationPictures",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    picture = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    destID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DestinationPictures", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DestinationPictures_Destination",
                        column: x => x.destID,
                        principalTable: "Destination",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "TourHasDestinations",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    destID = table.Column<int>(type: "int", nullable: false),
                    tourID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TourHasDestinations", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TourHasDestinations_Destination",
                        column: x => x.destID,
                        principalTable: "Destination",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_TourHasDestinations_Tour",
                        column: x => x.tourID,
                        principalTable: "Tour",
                        principalColumn: "ID");
                });

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
                name: "IX_City_governerateID",
                table: "City",
                column: "governerateID");

            migrationBuilder.CreateIndex(
                name: "IX_Destination_cityID",
                table: "Destination",
                column: "cityID");

            migrationBuilder.CreateIndex(
                name: "IX_DestinationPictures_destID",
                table: "DestinationPictures",
                column: "destID");

            migrationBuilder.CreateIndex(
                name: "IX_Excludes_tourID",
                table: "Excludes",
                column: "tourID");

            migrationBuilder.CreateIndex(
                name: "IX_Hotel_cityID",
                table: "Hotel",
                column: "cityID");

            migrationBuilder.CreateIndex(
                name: "IX_Includes_tourID",
                table: "Includes",
                column: "tourID");

            migrationBuilder.CreateIndex(
                name: "IX_Itinerary_tourID",
                table: "Itinerary",
                column: "tourID");

            migrationBuilder.CreateIndex(
                name: "IX_Market_cityID",
                table: "Market",
                column: "cityID");

            migrationBuilder.CreateIndex(
                name: "IX_Restaurant_cityID",
                table: "Restaurant",
                column: "cityID");

            migrationBuilder.CreateIndex(
                name: "IX_Tour_companyID",
                table: "Tour",
                column: "companyID");

            migrationBuilder.CreateIndex(
                name: "IX_tourHasActivities_activityID",
                table: "tourHasActivities",
                column: "activityID");

            migrationBuilder.CreateIndex(
                name: "IX_tourHasActivities_tourID",
                table: "tourHasActivities",
                column: "tourID");

            migrationBuilder.CreateIndex(
                name: "IX_TourHasDestinations_destID",
                table: "TourHasDestinations",
                column: "destID");

            migrationBuilder.CreateIndex(
                name: "IX_TourHasDestinations_tourID",
                table: "TourHasDestinations",
                column: "tourID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "DestinationPictures");

            migrationBuilder.DropTable(
                name: "Excludes");

            migrationBuilder.DropTable(
                name: "Hotel");

            migrationBuilder.DropTable(
                name: "Includes");

            migrationBuilder.DropTable(
                name: "Itinerary");

            migrationBuilder.DropTable(
                name: "Market");

            migrationBuilder.DropTable(
                name: "Restaurant");

            migrationBuilder.DropTable(
                name: "tourHasActivities");

            migrationBuilder.DropTable(
                name: "TourHasDestinations");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Activity");

            migrationBuilder.DropTable(
                name: "Destination");

            migrationBuilder.DropTable(
                name: "Tour");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "TourCompany");

            migrationBuilder.DropTable(
                name: "Governorate");
        }
    }
}
