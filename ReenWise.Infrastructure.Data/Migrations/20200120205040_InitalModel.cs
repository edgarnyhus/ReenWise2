using System;
using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;

namespace ReenWise.Infrastructure.Data.Migrations
{
    public partial class InitalModel : Migration
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
                    ManufacturerId = table.Column<Guid>(nullable: true)
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
                    Location = table.Column<Point>(type: "geometry", nullable: false),
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
                    Location = table.Column<Point>(type: "geometry", nullable: false),
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
                    { new Guid("d12520c6-56a4-4ce0-b9cb-afeaa96277ac"), "Nordcon AS" },
                    { new Guid("dcbdd01d-fbf8-4b42-8a0e-e814acfb6ec0"), "BNS Container AS" }
                });

            migrationBuilder.InsertData(
                table: "Organizations",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("d4457ee2-8690-4367-b9e2-39b300581556"), "Norsk Gjenvinning AS" },
                    { new Guid("2cbeca1a-d4db-41f3-bd14-38922aa0b76f"), "SmartContainer AS" }
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
