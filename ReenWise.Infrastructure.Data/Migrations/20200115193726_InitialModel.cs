using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ReenWise.Infrastructure.Data.Migrations
{
    public partial class InitialModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LicensePlates",
                columns: table => new
                {
                    Id = table.Column<Guid>(maxLength: 128, nullable: false),
                    Number = table.Column<string>(maxLength: 8, nullable: false),
                    RegistrationDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LicensePlates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Manufacturers",
                columns: table => new
                {
                    Id = table.Column<Guid>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacturers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OdoMeters",
                columns: table => new
                {
                    Id = table.Column<Guid>(maxLength: 128, nullable: false),
                    Value = table.Column<float>(nullable: false),
                    Timestamp = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OdoMeters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OperatingHours",
                columns: table => new
                {
                    Id = table.Column<Guid>(maxLength: 128, nullable: false),
                    Hours = table.Column<int>(nullable: false),
                    UnitDriven = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperatingHours", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Organizations",
                columns: table => new
                {
                    Id = table.Column<Guid>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Units",
                columns: table => new
                {
                    Id = table.Column<Guid>(maxLength: 128, nullable: false),
                    SerialNumber = table.Column<string>(maxLength: 32, nullable: true),
                    Type = table.Column<string>(maxLength: 32, nullable: true),
                    Health = table.Column<string>(maxLength: 32, nullable: true),
                    Status = table.Column<string>(maxLength: 32, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Models",
                columns: table => new
                {
                    Id = table.Column<Guid>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    SerialNumber = table.Column<string>(maxLength: 32, nullable: true),
                    Description = table.Column<string>(maxLength: 512, nullable: true),
                    Weight = table.Column<float>(nullable: true),
                    HHeight = table.Column<float>(nullable: true),
                    Length = table.Column<float>(nullable: true),
                    Width = table.Column<float>(nullable: true),
                    Volume = table.Column<float>(nullable: true),
                    Attachment = table.Column<string>(maxLength: 256, nullable: true),
                    ManufacturerId = table.Column<Guid>(nullable: true),
                    ManufactorerId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Models", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Models_Manufacturers_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalTable: "Manufacturers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Drivers",
                columns: table => new
                {
                    Id = table.Column<Guid>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 32, nullable: false),
                    Email = table.Column<string>(maxLength: 32, nullable: true),
                    OrganizationId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Drivers_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Equipment",
                columns: table => new
                {
                    Id = table.Column<Guid>(maxLength: 128, nullable: false),
                    Alias = table.Column<string>(maxLength: 128, nullable: false),
                    SerialNumber = table.Column<string>(maxLength: 32, nullable: true),
                    ModelId = table.Column<Guid>(nullable: true),
                    OperatingHoursId = table.Column<Guid>(nullable: true),
                    UnitId = table.Column<Guid>(nullable: true),
                    OrganizationId = table.Column<Guid>(nullable: true),
                    InitialOperatingHoursId = table.Column<Guid>(nullable: true),
                    Notes = table.Column<string>(maxLength: 1024, nullable: true),
                    ManufacturerId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Equipment_OperatingHours_InitialOperatingHoursId",
                        column: x => x.InitialOperatingHoursId,
                        principalTable: "OperatingHours",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Equipment_Manufacturers_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalTable: "Manufacturers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Equipment_Models_ModelId",
                        column: x => x.ModelId,
                        principalTable: "Models",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Equipment_OperatingHours_OperatingHoursId",
                        column: x => x.OperatingHoursId,
                        principalTable: "OperatingHours",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Equipment_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Equipment_Units_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<Guid>(maxLength: 128, nullable: false),
                    Alias = table.Column<string>(maxLength: 128, nullable: false),
                    ModelId = table.Column<Guid>(nullable: false),
                    LicensePlateId = table.Column<Guid>(nullable: false),
                    RegisteredAt = table.Column<DateTime>(nullable: false),
                    CommercialClass = table.Column<string>(maxLength: 32, nullable: true),
                    UnitId = table.Column<Guid>(nullable: true),
                    DriverId = table.Column<Guid>(nullable: true),
                    OrganizationId = table.Column<Guid>(nullable: false),
                    OdoMeterId = table.Column<Guid>(nullable: true),
                    Notes = table.Column<string>(maxLength: 1024, nullable: true),
                    FuelType = table.Column<string>(maxLength: 32, nullable: true),
                    EngineSize = table.Column<float>(nullable: true),
                    Color = table.Column<string>(maxLength: 32, nullable: true),
                    Co2Emissions = table.Column<float>(nullable: true),
                    ManufacturerId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehicles_Drivers_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Drivers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vehicles_LicensePlates_LicensePlateId",
                        column: x => x.LicensePlateId,
                        principalTable: "LicensePlates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vehicles_Manufacturers_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalTable: "Manufacturers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vehicles_Models_ModelId",
                        column: x => x.ModelId,
                        principalTable: "Models",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vehicles_OdoMeters_OdoMeterId",
                        column: x => x.OdoMeterId,
                        principalTable: "OdoMeters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vehicles_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vehicles_Units_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<Guid>(maxLength: 128, nullable: false),
                    Latitude = table.Column<float>(nullable: false),
                    Longitude = table.Column<float>(nullable: false),
                    InMovement = table.Column<bool>(nullable: false),
                    Timestamp = table.Column<DateTime>(nullable: false),
                    SignalSource = table.Column<string>(nullable: true),
                    Speed = table.Column<int>(nullable: true),
                    Course = table.Column<int>(nullable: true),
                    AccuracyRadius = table.Column<float>(nullable: true),
                    EquipmentId = table.Column<Guid>(nullable: true),
                    VehicleId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Locations_Equipment_EquipmentId",
                        column: x => x.EquipmentId,
                        principalTable: "Equipment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Locations_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Temperatures",
                columns: table => new
                {
                    Id = table.Column<Guid>(maxLength: 128, nullable: false),
                    Value = table.Column<float>(nullable: false),
                    Timestamp = table.Column<DateTime>(nullable: false),
                    EquipmentId = table.Column<Guid>(nullable: true),
                    VehicleId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Temperatures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Temperatures_Equipment_EquipmentId",
                        column: x => x.EquipmentId,
                        principalTable: "Equipment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Temperatures_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Manufacturers",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("31f0f55a-0ccc-4db2-9c9e-38004a336b77"), "Nordcon AS" },
                    { new Guid("4b23aa38-355d-49ad-8a05-967fc1136183"), "BNS Container AS" }
                });

            migrationBuilder.InsertData(
                table: "Models",
                columns: new[] { "Id", "Attachment", "Description", "HHeight", "Length", "ManufactorerId", "ManufacturerId", "Name", "SerialNumber", "Volume", "Weight", "Width" },
                values: new object[,]
                {
                    { new Guid("be2ef4b7-4d13-4a05-9806-66465b2bbb66"), null, "B3", null, null, null, null, "DAJLJA C-05L-L", "MUM030887", null, null, null },
                    { new Guid("02548f4e-84bf-4e99-87ce-b9d7c8f98986"), null, "C Estetisk stygg", null, null, null, null, "EAARST C-10L", "MUM030467", null, null, null },
                    { new Guid("356cf5b4-cdc2-42c2-96bd-7c660abe583c"), null, "C Estetisk stygg", null, null, null, null, "EABXEL C-10L", "MUM030764", null, null, null },
                    { new Guid("cf161733-ac50-4cea-9f2b-eada036d1203"), null, "B Estetisk stygg", null, null, null, null, "EACHRX C-08CL", "MUM030719", null, null, null },
                    { new Guid("bac1e53d-2781-4e8a-a93f-c697c37c2084"), null, "B Estetisk stygg", null, null, null, null, "EADRBA C-08CL", "MUM030746", null, null, null },
                    { new Guid("66610c67-074c-43f9-9607-581435eabb2a"), null, "B Fin", null, null, null, null, "EAEATJ C-22K", "MUM029340", null, null, null },
                    { new Guid("4953ad33-a8a0-46fc-a775-a902c97ec75d"), null, "A Fin", null, null, null, null, "EAGUUU C-08CL", "MUM030683", null, null, null },
                    { new Guid("da0d6031-4532-4314-9725-bbb8bf7aada3"), null, "C Estetisk stygg", null, null, null, null, "EAHBYT C-10CL", "MUM030741", null, null, null },
                    { new Guid("8fb1111f-b0c5-4097-bc93-755413fec430"), null, "A Fin", null, null, null, null, "EAJFGU C-10LL", "MUM029330", null, null, null },
                    { new Guid("569918b6-eb5d-49b9-9fb9-645dfb71dbfb"), null, "C Estetisk stygg", null, null, null, null, "EAKNKF C-10CL", "MUM030743", null, null, null },
                    { new Guid("c862e37d-a574-4442-be50-f9cbbe3b926e"), null, "C Estetisk stygg", null, null, null, null, "EALUNJ C-10L", "MUM030509", null, null, null },
                    { new Guid("70af57fc-7279-4868-b005-cf1b04b8e058"), null, "C Estetisk stygg", null, null, null, null, "EANVZX C-22K", "MUM030724", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Organizations",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("03c93f3f-3381-4690-8e52-96b3c224a74d"), "Norsk Gjenvinning AS" },
                    { new Guid("ca5515f4-89c1-4558-8e06-075f38a20a2e"), "SmartContainer AS" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Drivers_OrganizationId",
                table: "Drivers",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_InitialOperatingHoursId",
                table: "Equipment",
                column: "InitialOperatingHoursId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_ManufacturerId",
                table: "Equipment",
                column: "ManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_ModelId",
                table: "Equipment",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_OperatingHoursId",
                table: "Equipment",
                column: "OperatingHoursId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_OrganizationId",
                table: "Equipment",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_UnitId",
                table: "Equipment",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_EquipmentId",
                table: "Locations",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_VehicleId",
                table: "Locations",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_Models_ManufacturerId",
                table: "Models",
                column: "ManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_Temperatures_EquipmentId",
                table: "Temperatures",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Temperatures_VehicleId",
                table: "Temperatures",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_DriverId",
                table: "Vehicles",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_LicensePlateId",
                table: "Vehicles",
                column: "LicensePlateId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_ManufacturerId",
                table: "Vehicles",
                column: "ManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_ModelId",
                table: "Vehicles",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_OdoMeterId",
                table: "Vehicles",
                column: "OdoMeterId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_OrganizationId",
                table: "Vehicles",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_UnitId",
                table: "Vehicles",
                column: "UnitId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Temperatures");

            migrationBuilder.DropTable(
                name: "Equipment");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "OperatingHours");

            migrationBuilder.DropTable(
                name: "Drivers");

            migrationBuilder.DropTable(
                name: "LicensePlates");

            migrationBuilder.DropTable(
                name: "Models");

            migrationBuilder.DropTable(
                name: "OdoMeters");

            migrationBuilder.DropTable(
                name: "Units");

            migrationBuilder.DropTable(
                name: "Organizations");

            migrationBuilder.DropTable(
                name: "Manufacturers");
        }
    }
}
