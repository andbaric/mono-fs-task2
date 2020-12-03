using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Project.DAL.Migrations
{
    public partial class DataSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "vehicle_make",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Abrv = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vehicle_make", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "vehicle_model",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MakeId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Abrv = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vehicle_model", x => x.Id);
                    table.ForeignKey(
                        name: "FK_vehicle_model_vehicle_make_MakeId",
                        column: x => x.MakeId,
                        principalTable: "vehicle_make",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "vehicle_make",
                columns: new[] { "Id", "Abrv", "Name" },
                values: new object[,]
                {
                    { new Guid("160629cb-34d0-48dc-bd6a-4d0895f9b7f7"), "BMW", "Bayerische Motoren Werke" },
                    { new Guid("5e7f0599-a1a0-43fb-a12c-fc278402ea0a"), "Hyundai", "Hyundai" },
                    { new Guid("942e29d9-ab57-4459-9171-200781e9ac57"), "Kia", "Kia" },
                    { new Guid("061fe685-971d-46e6-b374-a95baa59fcc4"), "Mercedes", "Mercedes-Benz" },
                    { new Guid("22ecc5e7-c688-4f7e-aac3-5595d7334bd8"), "Mitsubishi", "Mitsubishi" },
                    { new Guid("039fd2e6-e674-4599-9d33-1139823a74f0"), "Suzuki", "Suzuki" },
                    { new Guid("2f6446cf-b745-4c95-ac55-afe92487610d"), "Honda", "Honda" },
                    { new Guid("a40c6c8e-cff7-4b53-9a92-2bb83ca36cbc"), "Nissan", "Nissan" },
                    { new Guid("d50672a0-e817-4a64-9c89-9208cac982f9"), "Toyota", "Toyota" },
                    { new Guid("2561ad51-2c14-430f-bc1f-01672bf5630c"), "Peugeot", "Peugeot" },
                    { new Guid("b79c07a7-365c-4e4f-a1c9-7ebfc46b8513"), "Ford", "Ford" },
                    { new Guid("4a71f24f-50f1-4f49-8580-cbfc7b80b3e5"), "Renault", "Renault" },
                    { new Guid("127d1017-190f-4c29-996e-80b20d14782b"), "Audi", "Audi" },
                    { new Guid("61e200a0-d22e-4166-a221-51ca209f2dbb"), "Opel", "Opel" },
                    { new Guid("cd312e9e-73fd-46c3-b6af-127008e82fb6"), "VW", "Volkswagen" },
                    { new Guid("cd798a79-200f-4071-ba1e-4e84e6e01aff"), "Mazda", "Mazda" },
                    { new Guid("6bcdfb19-6224-49ce-9bdb-6562c0f2586b"), "Rimac", "Rimac" }
                });

            migrationBuilder.InsertData(
                table: "vehicle_model",
                columns: new[] { "Id", "Abrv", "MakeId", "Name" },
                values: new object[,]
                {
                    { new Guid("9df3cb71-16b5-4890-9d7d-dea31669db72"), "X5", new Guid("160629cb-34d0-48dc-bd6a-4d0895f9b7f7"), "X5 (BMW)" },
                    { new Guid("1346b937-cda7-4d9f-824d-bc3fb17659b6"), "Yaris", new Guid("d50672a0-e817-4a64-9c89-9208cac982f9"), "Yaris (Toyota)" },
                    { new Guid("05d1869c-3ccf-4885-8d13-cd329a309ec9"), "Auris", new Guid("d50672a0-e817-4a64-9c89-9208cac982f9"), "Auris (Toyota)" },
                    { new Guid("5b5f79f7-ab2f-48ce-a02d-ed622bab9a17"), "CR-V", new Guid("2f6446cf-b745-4c95-ac55-afe92487610d"), "CR-V (Honda)" },
                    { new Guid("ef68b28b-663b-4604-aca3-8baad3703692"), "Accord", new Guid("2f6446cf-b745-4c95-ac55-afe92487610d"), "Accord (Honda)" },
                    { new Guid("18d8b8f1-215e-49f9-9ad8-9e1f10aaad3d"), "SWIFT", new Guid("039fd2e6-e674-4599-9d33-1139823a74f0"), "Swift (Suzuki)" },
                    { new Guid("9c3a8354-bf32-4997-85f4-a5eaf7a66478"), "Ignis", new Guid("039fd2e6-e674-4599-9d33-1139823a74f0"), "Ignis (Suzuki) " },
                    { new Guid("46176513-eb86-4585-8c37-e05a802c9fd4"), "Corola", new Guid("d50672a0-e817-4a64-9c89-9208cac982f9"), "Corola (Toyota) " },
                    { new Guid("67d5ff55-f55e-4daa-818f-e857f5a0a51b"), "Jimny", new Guid("039fd2e6-e674-4599-9d33-1139823a74f0"), "Jimny 7 (Suzuki)" },
                    { new Guid("847e2f9b-e47b-44ce-bba8-689b25730705"), "Mirage", new Guid("22ecc5e7-c688-4f7e-aac3-5595d7334bd8"), "Mirage (Mitsubishi) " },
                    { new Guid("c9186453-b5b9-49e1-9c11-e9675ddb7993"), "G-Class", new Guid("061fe685-971d-46e6-b374-a95baa59fcc4"), "G-Class (Mercedes)" },
                    { new Guid("dc51aa3b-472e-4a8d-8d53-f14bbcafe65a"), "Kona", new Guid("942e29d9-ab57-4459-9171-200781e9ac57"), "Kona (Kia)" },
                    { new Guid("88aa7a7d-4762-48f1-b3e0-309b256dd3e6"), "Sportage", new Guid("942e29d9-ab57-4459-9171-200781e9ac57"), "Sportage (Kia) " },
                    { new Guid("4c05e868-63f5-4943-9f6a-e34dc90c5315"), "Rio", new Guid("942e29d9-ab57-4459-9171-200781e9ac57"), "Rio (Kia)" },
                    { new Guid("57c7b7b3-d2e8-4710-a002-7f600d449296"), "Qashqai", new Guid("a40c6c8e-cff7-4b53-9a92-2bb83ca36cbc"), "Qashqai (Nissan)" },
                    { new Guid("ababecc8-e9e0-4b96-9536-a42b7bce4dec"), "Lancer", new Guid("22ecc5e7-c688-4f7e-aac3-5595d7334bd8"), "Lancer (Mitsubishi)" },
                    { new Guid("5e852ab4-3d11-4c58-9dbe-4b695911f0f0"), "RAV4", new Guid("d50672a0-e817-4a64-9c89-9208cac982f9"), "RAV4 (Toyota)" },
                    { new Guid("4de345e7-a4e5-4f6a-bf87-71bc77c18292"), "3", new Guid("cd798a79-200f-4071-ba1e-4e84e6e01aff"), "3 (Mazda)" },
                    { new Guid("c336a949-372c-4b29-b5b9-96220f099275"), "6", new Guid("cd798a79-200f-4071-ba1e-4e84e6e01aff"), "6 (Mazda)" },
                    { new Guid("cc84e81a-fed6-420f-b213-a7d901359195"), "M4", new Guid("160629cb-34d0-48dc-bd6a-4d0895f9b7f7"), "M4 (BMW)" },
                    { new Guid("a4691064-2184-4010-9c95-5a438905e0d3"), "Golf 7", new Guid("cd312e9e-73fd-46c3-b6af-127008e82fb6"), "Golf 7 (VW)" },
                    { new Guid("f7c488ab-2f7e-489d-8766-d5cb9bacc952"), "Pasat", new Guid("cd312e9e-73fd-46c3-b6af-127008e82fb6"), "Pasat (VW)" },
                    { new Guid("2f6f2061-1da1-4122-8160-04f75255e204"), "Arteon", new Guid("cd312e9e-73fd-46c3-b6af-127008e82fb6"), "Arteon (VW) " },
                    { new Guid("e5e10ae8-d15c-4b1d-a237-f591dc3af2fd"), "Corsa", new Guid("61e200a0-d22e-4166-a221-51ca209f2dbb"), "Corsa (Opel)" },
                    { new Guid("a2a99cae-5709-40cf-a3cd-60fb33c33d6e"), "A4", new Guid("127d1017-190f-4c29-996e-80b20d14782b"), "A4 (Audi)" },
                    { new Guid("61bebc38-f655-4586-9892-d6bf41908f4e"), "Q5", new Guid("127d1017-190f-4c29-996e-80b20d14782b"), "Q5 (Audi) " },
                    { new Guid("56393b10-669f-48bc-be90-48d9b2880783"), "Q7", new Guid("127d1017-190f-4c29-996e-80b20d14782b"), "Q7 (Audi)" },
                    { new Guid("08b042bc-ee54-4c58-a440-b4fca64ad074"), "Megane", new Guid("4a71f24f-50f1-4f49-8580-cbfc7b80b3e5"), "Megane (Renault)" },
                    { new Guid("84d76b7a-de72-4fa1-a79b-dba781e0e124"), "Renault", new Guid("4a71f24f-50f1-4f49-8580-cbfc7b80b3e5"), "Clio (Renault) " },
                    { new Guid("0f1367cd-b5c0-4d1a-a083-202d47ef7821"), "Mondeo", new Guid("b79c07a7-365c-4e4f-a1c9-7ebfc46b8513"), "Mondeo (Ford)" },
                    { new Guid("6a3069b4-8527-47de-b514-32c202c6a06d"), "Mustang", new Guid("b79c07a7-365c-4e4f-a1c9-7ebfc46b8513"), "Mustang (Ford)" },
                    { new Guid("3b8e4bb3-208b-4863-a0aa-13e69a452462"), "Fiesta", new Guid("b79c07a7-365c-4e4f-a1c9-7ebfc46b8513"), "Fiesta (Ford) " },
                    { new Guid("7dda9308-0159-40b8-9d6a-23a4ef10003d"), "Focus", new Guid("b79c07a7-365c-4e4f-a1c9-7ebfc46b8513"), "Focus (Ford)" },
                    { new Guid("fb27de52-23fe-477e-8afa-ad9551f82d4d"), "206", new Guid("2561ad51-2c14-430f-bc1f-01672bf5630c"), "206 (Peugeot)" },
                    { new Guid("ace5d013-6a3c-4255-b8e6-ec1e68e7b9b1"), "Juke", new Guid("a40c6c8e-cff7-4b53-9a92-2bb83ca36cbc"), "Juke (Nissan)" },
                    { new Guid("70203419-5052-4f7c-a403-8f3f54736bbb"), "Concept_One", new Guid("6bcdfb19-6224-49ce-9bdb-6562c0f2586b"), "Concept_One (Rimac)" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_vehicle_model_MakeId",
                table: "vehicle_model",
                column: "MakeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "vehicle_model");

            migrationBuilder.DropTable(
                name: "vehicle_make");
        }
    }
}
