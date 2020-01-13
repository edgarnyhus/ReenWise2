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
                    { new Guid("fa6d7df6-8b73-4e94-9f02-87c8496345bf"), "Nordcon AS" },
                    { new Guid("1157b2ae-384b-49bf-9770-7cf2e7cab37b"), "BNS Container AS" }
                });

            migrationBuilder.InsertData(
                table: "Models",
                columns: new[] { "Id", "Attachment", "Description", "HHeight", "Length", "ManufactorerId", "ManufacturerId", "Name", "SerialNumber", "Volume", "Weight", "Width" },
                values: new object[,]
                {
                    { new Guid("9d761bf4-c825-4718-bc5a-07c9b13d0e55"), null, "B3", null, null, null, null, "DAJLJA C-05L-L", "MUM030887", null, null, null },
                    { new Guid("9350a074-741d-48d6-97fe-89fb5839887f"), null, "C Estetisk stygg", null, null, null, null, "EAARST C-10L", "MUM030467", null, null, null },
                    { new Guid("31ec567e-530f-450a-acd4-c421a9629515"), null, "C Estetisk stygg", null, null, null, null, "EABXEL C-10L", "MUM030764", null, null, null },
                    { new Guid("78dcdebf-fcdf-4c1e-860c-238dd3cd9f8c"), null, "B Estetisk stygg", null, null, null, null, "EACHRX C-08CL", "MUM030719", null, null, null },
                    { new Guid("be7d8152-565a-4d54-81fb-8322c9e813ea"), null, "B Estetisk stygg", null, null, null, null, "EADRBA C-08CL", "MUM030746", null, null, null },
                    { new Guid("49cf1665-0991-4225-b66a-c3f0faac30d0"), null, "B Fin", null, null, null, null, "EAEATJ C-22K", "MUM029340", null, null, null },
                    { new Guid("3cd00b26-0f79-41a0-9a0b-53bf569fa68e"), null, "A Fin", null, null, null, null, "EAGUUU C-08CL", "MUM030683", null, null, null },
                    { new Guid("169d6027-2165-47f7-96e4-7d274e457d89"), null, "C Estetisk stygg", null, null, null, null, "EAHBYT C-10CL", "MUM030741", null, null, null },
                    { new Guid("d3788f7d-a463-4bc5-8d4e-510513dae67a"), null, "A Fin", null, null, null, null, "EAJFGU C-10LL", "MUM029330", null, null, null },
                    { new Guid("1c472b8d-17a5-44b6-a5b7-e982f9a7666c"), null, "C Estetisk stygg", null, null, null, null, "EAKNKF C-10CL", "MUM030743", null, null, null },
                    { new Guid("5268323a-7572-46a0-8b08-c7cf785b8c05"), null, "C Estetisk stygg", null, null, null, null, "EALUNJ C-10L", "MUM030509", null, null, null },
                    { new Guid("8cfea25b-2a65-45f0-bb7c-170c6aea13b4"), null, "C Estetisk stygg", null, null, null, null, "EANVZX C-22K", "MUM030724", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Organizations",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("06de7551-ca60-4c5c-9c27-a2df6af7fd64"), "Norsk Gjenvinning AS" },
                    { new Guid("e76173a3-676e-421e-9e4f-4a64efb35544"), "SmartContainer AS" }
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
