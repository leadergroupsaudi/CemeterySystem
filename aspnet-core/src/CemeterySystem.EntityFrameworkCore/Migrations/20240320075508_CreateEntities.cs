using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CemeterySystem.Migrations
{
    /// <inheritdoc />
    public partial class CreateEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    NameAr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameAr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegionId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_Regions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Regions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Districts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameAr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Districts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Districts_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cemeteries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    DistrictId = table.Column<int>(type: "int", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OpenTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    CloseTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    Status = table.Column<byte>(type: "tinyint", nullable: false),
                    AddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cemeteries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cemeteries_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Cemeteries_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cemeteries_Districts_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "Districts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Volunteer",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    NameAr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DistrictId = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Volunteer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Volunteer_Districts_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "Districts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Burials",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CemeteryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<byte>(type: "tinyint", nullable: false),
                    AddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Burials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Burials_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Burials_Cemeteries_CemeteryId",
                        column: x => x.CemeteryId,
                        principalTable: "Cemeteries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PrayerPlaces",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Facility = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<byte>(type: "tinyint", nullable: false),
                    AddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CemeteryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrayerPlaces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PrayerPlaces_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PrayerPlaces_Cemeteries_CemeteryId",
                        column: x => x.CemeteryId,
                        principalTable: "Cemeteries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VolunteerOrder",
                columns: table => new
                {
                    CemeteryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VolunteerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VolunteerOrder", x => new { x.CemeteryId, x.VolunteerId });
                    table.ForeignKey(
                        name: "FK_VolunteerOrder_Cemeteries_CemeteryId",
                        column: x => x.CemeteryId,
                        principalTable: "Cemeteries",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_VolunteerOrder_Volunteer_VolunteerId",
                        column: x => x.VolunteerId,
                        principalTable: "Volunteer",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Deceaseds",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BurialId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PrayerPlaceId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RegionId = table.Column<int>(type: "int", nullable: true),
                    NameAr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserIdentity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BurialDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PrayerTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<byte>(type: "tinyint", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deceaseds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Deceaseds_Burials_BurialId",
                        column: x => x.BurialId,
                        principalTable: "Burials",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Deceaseds_PrayerPlaces_PrayerPlaceId",
                        column: x => x.PrayerPlaceId,
                        principalTable: "PrayerPlaces",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Deceaseds_Regions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Regions",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "IsDeleted", "NameAr", "NameEn" },
                values: new object[] { 1, null, false, "المنطقة الشرقية", "EAMANA" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "IsDeleted", "NameAr", "NameEn", "RegionId" },
                values: new object[,]
                {
                    { 1, false, "الدمام", null, 1 },
                    { 2, false, "الظهران", null, 1 },
                    { 3, false, "الخبر", null, 1 },
                    { 4, false, "القطيف", null, 1 },
                    { 5, false, "سيهات", null, 1 },
                    { 6, false, "تاروت", null, 1 },
                    { 7, false, "عنك", null, 1 },
                    { 8, false, "صفوى", null, 1 },
                    { 9, false, "", null, 1 },
                    { 10, false, "راس تنورة", null, 1 },
                    { 11, false, "الجبيل", null, 1 }
                });

            migrationBuilder.InsertData(
                table: "Cemeteries",
                columns: new[] { "Id", "AddressId", "CityId", "CloseTime", "DistrictId", "IsDeleted", "NameAr", "NameEn", "OpenTime", "Phone", "Status" },
                values: new object[,]
                {
                    { new Guid("09767108-f692-46bf-9a74-fbdc7d388fb8"), null, 2, new TimeSpan(0, 0, 0, 0, 0), null, false, "مقبرة بقيق الجديدة", "New Buqayq Cemetery", new TimeSpan(0, 0, 0, 0, 0), null, (byte)0 },
                    { new Guid("0fe78776-28ef-4db8-b9f7-4063fac34a4e"), null, 2, new TimeSpan(0, 0, 0, 0, 0), null, false, "مقبرة بقيق", "Buqayq Cemetery", new TimeSpan(0, 0, 0, 0, 0), null, (byte)0 },
                    { new Guid("17b3d093-6f04-4422-9fac-ef70c1c9d6fe"), null, 2, new TimeSpan(0, 0, 0, 0, 0), null, false, "مقبرة الخفجي", "Al Khafji Cemetery", new TimeSpan(0, 0, 0, 0, 0), null, (byte)0 },
                    { new Guid("23a3aa3e-afda-483f-9f60-dc8c1083bcd6"), null, 1, new TimeSpan(0, 0, 0, 0, 0), null, false, "مقبرة أم الحمام", "Umm Al-Hamam Cemetery", new TimeSpan(0, 0, 0, 0, 0), null, (byte)0 },
                    { new Guid("33733666-7ec7-48dc-a0dc-2ef7d1bf0b76"), null, 2, new TimeSpan(0, 0, 0, 0, 0), null, false, "مقبرة رشالا (القديح)", "Rashalah Cemetery", new TimeSpan(0, 0, 0, 0, 0), null, (byte)0 },
                    { new Guid("34aa9c83-b627-445f-a729-db81f64e754a"), null, 1, new TimeSpan(0, 0, 0, 0, 0), null, false, "مقبرة الثقبة", "Thuqba Cemetery", new TimeSpan(0, 0, 0, 0, 0), null, (byte)0 },
                    { new Guid("47afae92-cc34-4126-8c44-46ed8d78c23a"), null, 2, new TimeSpan(0, 0, 0, 0, 0), null, false, "مقبرة رأس تنورة", "Ras Tanura Cemetery", new TimeSpan(0, 0, 0, 0, 0), null, (byte)0 },
                    { new Guid("49aee77b-ede0-4571-9243-74fbdd0583fd"), null, 2, new TimeSpan(0, 0, 0, 0, 0), null, false, "المقبرة الغربية", "Western Cemetery", new TimeSpan(0, 0, 0, 0, 0), null, (byte)0 },
                    { new Guid("58c2571c-1837-42ce-a352-f241c3ece2c5"), null, 1, new TimeSpan(0, 0, 0, 0, 0), null, false, "مقبرة الدمام", "Dammam Cemetery", new TimeSpan(0, 0, 0, 0, 0), null, (byte)0 },
                    { new Guid("61465f63-285e-4291-98d5-5edbe6233a37"), null, 2, new TimeSpan(0, 0, 0, 0, 0), null, false, "مقبرة عريعرة", "Urayarah Cemetery", new TimeSpan(0, 0, 0, 0, 0), null, (byte)0 },
                    { new Guid("93ee512a-6037-4621-a933-e181ca1b0a1f"), null, 1, new TimeSpan(0, 0, 0, 0, 0), null, false, "المقبرة الجنوبية", "Southern Cemetery", new TimeSpan(0, 0, 0, 0, 0), null, (byte)0 },
                    { new Guid("98065b56-321e-4604-b60a-ca482defd1ca"), null, 1, new TimeSpan(0, 0, 0, 0, 0), null, false, "مقبرة عين دار الجديدة", "New Ain Dar Cemetery", new TimeSpan(0, 0, 0, 0, 0), null, (byte)0 },
                    { new Guid("afcc0651-434b-4101-bb3f-2263f4c57dff"), null, 2, new TimeSpan(0, 0, 0, 0, 0), null, false, "مقبرة الخبَّـاقة", "Al-Khabbaga Cemetery", new TimeSpan(0, 0, 0, 0, 0), null, (byte)0 },
                    { new Guid("d58c5e59-1dd4-418d-b0a5-6fdd22e13ed0"), null, 1, new TimeSpan(0, 0, 0, 0, 0), null, false, "مقبرة عنك", "Anak Cemetery", new TimeSpan(0, 0, 0, 0, 0), null, (byte)0 },
                    { new Guid("e1e2f3e4-6d61-4fcc-9264-e0c175d9040f"), null, 1, new TimeSpan(0, 0, 0, 0, 0), null, false, "مقبرة الدمام القديمة", "Dammam Old Cemetery", new TimeSpan(0, 0, 0, 0, 0), null, (byte)0 },
                    { new Guid("f02abe46-ee0f-44c5-b688-5f3956674c10"), null, 1, new TimeSpan(0, 0, 0, 0, 0), null, false, "مقبرة سيهات", "Saihat Cemetery", new TimeSpan(0, 0, 0, 0, 0), null, (byte)0 },
                    { new Guid("f2205b7f-0b75-4bf5-a535-7fb352c85110"), null, 1, new TimeSpan(0, 0, 0, 0, 0), null, false, "مقبرة الدبابية", "Dababiyyah Cemetery", new TimeSpan(0, 0, 0, 0, 0), null, (byte)0 },
                    { new Guid("f52296a1-60bc-49cd-bed7-4fc69b54f012"), null, 2, new TimeSpan(0, 0, 0, 0, 0), null, false, "مقبرة تاروت", "Tarout Cemetery", new TimeSpan(0, 0, 0, 0, 0), null, (byte)0 }
                });

            migrationBuilder.InsertData(
                table: "Districts",
                columns: new[] { "Id", "CityId", "IsDeleted", "NameAr", "NameEn" },
                values: new object[,]
                {
                    { 1, 1, false, "المريكبات", null },
                    { 2, 1, false, "الاسكان", null },
                    { 3, 1, false, "البساتين", null },
                    { 4, 1, false, "الروضة", null },
                    { 5, 1, false, "الريان", null },
                    { 6, 1, false, "المطار", null },
                    { 7, 1, false, "الصناعية الأولى", null },
                    { 8, 1, false, "النزهة", null },
                    { 9, 1, false, "الفيصلية", null },
                    { 10, 1, false, "السيف", null },
                    { 11, 1, false, "الجامعيين", null },
                    { 12, 1, false, "المنار", null },
                    { 13, 1, false, "الأمانة", null },
                    { 14, 1, false, "النهضة", null },
                    { 15, 1, false, "الفردوس", null },
                    { 16, 1, false, "الندى", null },
                    { 17, 1, false, "الواحة", null },
                    { 18, 1, false, "المنتزة", null },
                    { 19, 2, false, "الدوحة الجنوبية", null },
                    { 20, 2, false, "القصور", null },
                    { 21, 2, false, "القشلة", null },
                    { 22, 2, false, "الدانة الشمالية", null },
                    { 23, 2, false, "الدوحة الشمالية", null },
                    { 24, 2, false, "الدانة الجنوبية", null },
                    { 25, 2, false, "الجامعة", null },
                    { 26, 2, false, "جامعة الملك فهد للبترول والمعادن", null },
                    { 27, 2, false, "غرب الظهران", null },
                    { 28, 2, false, "الحرس الوطني", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Burials_AddressId",
                table: "Burials",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Burials_CemeteryId",
                table: "Burials",
                column: "CemeteryId");

            migrationBuilder.CreateIndex(
                name: "IX_Cemeteries_AddressId",
                table: "Cemeteries",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Cemeteries_CityId",
                table: "Cemeteries",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Cemeteries_DistrictId",
                table: "Cemeteries",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_RegionId",
                table: "Cities",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Deceaseds_BurialId",
                table: "Deceaseds",
                column: "BurialId");

            migrationBuilder.CreateIndex(
                name: "IX_Deceaseds_PrayerPlaceId",
                table: "Deceaseds",
                column: "PrayerPlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Deceaseds_RegionId",
                table: "Deceaseds",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Districts_CityId",
                table: "Districts",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_PrayerPlaces_AddressId",
                table: "PrayerPlaces",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_PrayerPlaces_CemeteryId",
                table: "PrayerPlaces",
                column: "CemeteryId");

            migrationBuilder.CreateIndex(
                name: "IX_Volunteer_DistrictId",
                table: "Volunteer",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_Volunteer_Phone",
                table: "Volunteer",
                column: "Phone",
                unique: true,
                filter: "[Phone] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_VolunteerOrder_VolunteerId",
                table: "VolunteerOrder",
                column: "VolunteerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Deceaseds");

            migrationBuilder.DropTable(
                name: "VolunteerOrder");

            migrationBuilder.DropTable(
                name: "Burials");

            migrationBuilder.DropTable(
                name: "PrayerPlaces");

            migrationBuilder.DropTable(
                name: "Volunteer");

            migrationBuilder.DropTable(
                name: "Cemeteries");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Districts");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Regions");
        }
    }
}
