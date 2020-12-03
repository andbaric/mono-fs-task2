using Microsoft.EntityFrameworkCore;
using Project.DAL.Entities;
using System;
using System.Collections.Generic;

namespace Project.DAL
{
    public static class ModelBuilderExtensions 
    {
        public static void DecribeRelationships(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VehicleModel>()
                .HasOne<VehicleMake>()
                .WithMany()
                .HasForeignKey(property => property.MakeId);
        }

        public static void SeedData(this ModelBuilder modelBuilder)
        {
            var vehicleMakes = new List<VehicleMake>
            {
                new VehicleMake { Id = new Guid("160629cb-34d0-48dc-bd6a-4d0895f9b7f7"), Name = "Bayerische Motoren Werke", Abrv = "BMW" },
                new VehicleMake { Id = new Guid("cd312e9e-73fd-46c3-b6af-127008e82fb6"), Name = "Volkswagen", Abrv = "VW" },
                new VehicleMake { Id = new Guid("61e200a0-d22e-4166-a221-51ca209f2dbb"), Name = "Opel", Abrv = "Opel" },
                new VehicleMake { Id = new Guid("127d1017-190f-4c29-996e-80b20d14782b"), Name = "Audi", Abrv = "Audi" },
                new VehicleMake { Id = new Guid("4a71f24f-50f1-4f49-8580-cbfc7b80b3e5"), Name = "Renault", Abrv = "Renault" },
                new VehicleMake { Id = new Guid("b79c07a7-365c-4e4f-a1c9-7ebfc46b8513"), Name = "Ford", Abrv = "Ford" },
                new VehicleMake { Id = new Guid("2561ad51-2c14-430f-bc1f-01672bf5630c"), Name = "Peugeot", Abrv = "Peugeot" },
                new VehicleMake { Id = new Guid("cd798a79-200f-4071-ba1e-4e84e6e01aff"), Name = "Mazda", Abrv = "Mazda" },
                new VehicleMake { Id = new Guid("d50672a0-e817-4a64-9c89-9208cac982f9"), Name = "Toyota", Abrv = "Toyota" },
                new VehicleMake { Id = new Guid("2f6446cf-b745-4c95-ac55-afe92487610d"), Name = "Honda", Abrv = "Honda" },
                new VehicleMake { Id = new Guid("039fd2e6-e674-4599-9d33-1139823a74f0"), Name = "Suzuki", Abrv = "Suzuki" },
                new VehicleMake { Id = new Guid("22ecc5e7-c688-4f7e-aac3-5595d7334bd8"), Name = "Mitsubishi", Abrv = "Mitsubishi" },
                new VehicleMake { Id = new Guid("061fe685-971d-46e6-b374-a95baa59fcc4"), Name = "Mercedes-Benz", Abrv = "Mercedes" },
                new VehicleMake { Id = new Guid("942e29d9-ab57-4459-9171-200781e9ac57"), Name = "Kia", Abrv = "Kia" },
                new VehicleMake { Id = new Guid("5e7f0599-a1a0-43fb-a12c-fc278402ea0a"), Name = "Hyundai", Abrv = "Hyundai" },
                new VehicleMake { Id = new Guid("a40c6c8e-cff7-4b53-9a92-2bb83ca36cbc"), Name = "Nissan", Abrv = "Nissan" },
                new VehicleMake { Id = new Guid("6bcdfb19-6224-49ce-9bdb-6562c0f2586b"), Name = "Rimac", Abrv = "Rimac" },
            };
            modelBuilder.Entity<VehicleMake>().HasData(vehicleMakes);

            var vehicleModels = new List<VehicleModel>
            {
                new VehicleModel { Id = new Guid("9df3cb71-16b5-4890-9d7d-dea31669db72"), MakeId = new Guid("160629cb-34d0-48dc-bd6a-4d0895f9b7f7"), Name = "X5 (BMW)", Abrv = "X5" },
                new VehicleModel { Id = new Guid("cc84e81a-fed6-420f-b213-a7d901359195"), MakeId = new Guid("160629cb-34d0-48dc-bd6a-4d0895f9b7f7"), Name = "M4 (BMW)", Abrv = "M4" },
                new VehicleModel { Id = new Guid("a4691064-2184-4010-9c95-5a438905e0d3"), MakeId = new Guid("cd312e9e-73fd-46c3-b6af-127008e82fb6"), Name = "Golf 7 (VW)", Abrv = "Golf 7" },
                new VehicleModel { Id = new Guid("f7c488ab-2f7e-489d-8766-d5cb9bacc952"), MakeId = new Guid("cd312e9e-73fd-46c3-b6af-127008e82fb6"), Name = "Pasat (VW)", Abrv = "Pasat" },
                new VehicleModel { Id = new Guid("2f6f2061-1da1-4122-8160-04f75255e204"), MakeId = new Guid("cd312e9e-73fd-46c3-b6af-127008e82fb6"), Name = "Arteon (VW) ", Abrv = "Arteon" },
                new VehicleModel { Id = new Guid("e5e10ae8-d15c-4b1d-a237-f591dc3af2fd"), MakeId = new Guid("61e200a0-d22e-4166-a221-51ca209f2dbb"), Name = "Corsa (Opel)", Abrv = "Corsa" },
                new VehicleModel { Id = new Guid("a2a99cae-5709-40cf-a3cd-60fb33c33d6e"), MakeId = new Guid("127d1017-190f-4c29-996e-80b20d14782b"), Name = "A4 (Audi)", Abrv = "A4" },
                new VehicleModel { Id = new Guid("61bebc38-f655-4586-9892-d6bf41908f4e"), MakeId = new Guid("127d1017-190f-4c29-996e-80b20d14782b"), Name = "Q5 (Audi) ", Abrv = "Q5" },
                new VehicleModel { Id = new Guid("56393b10-669f-48bc-be90-48d9b2880783"), MakeId = new Guid("127d1017-190f-4c29-996e-80b20d14782b"), Name = "Q7 (Audi)", Abrv = "Q7" },
                new VehicleModel { Id = new Guid("08b042bc-ee54-4c58-a440-b4fca64ad074"), MakeId = new Guid("4a71f24f-50f1-4f49-8580-cbfc7b80b3e5"), Name = "Megane (Renault)", Abrv = "Megane" },
                new VehicleModel { Id = new Guid("84d76b7a-de72-4fa1-a79b-dba781e0e124"), MakeId = new Guid("4a71f24f-50f1-4f49-8580-cbfc7b80b3e5"), Name = "Clio (Renault) ", Abrv = "Renault" },
                new VehicleModel { Id = new Guid("0f1367cd-b5c0-4d1a-a083-202d47ef7821"), MakeId = new Guid("b79c07a7-365c-4e4f-a1c9-7ebfc46b8513"), Name = "Mondeo (Ford)", Abrv = "Mondeo" },
                new VehicleModel { Id = new Guid("6a3069b4-8527-47de-b514-32c202c6a06d"), MakeId = new Guid("b79c07a7-365c-4e4f-a1c9-7ebfc46b8513"), Name = "Mustang (Ford)", Abrv = "Mustang" },
                new VehicleModel { Id = new Guid("3b8e4bb3-208b-4863-a0aa-13e69a452462"), MakeId = new Guid("b79c07a7-365c-4e4f-a1c9-7ebfc46b8513"), Name = "Fiesta (Ford) ", Abrv = "Fiesta" },
                new VehicleModel { Id = new Guid("7dda9308-0159-40b8-9d6a-23a4ef10003d"), MakeId = new Guid("b79c07a7-365c-4e4f-a1c9-7ebfc46b8513"), Name = "Focus (Ford)", Abrv = "Focus" },
                new VehicleModel { Id = new Guid("fb27de52-23fe-477e-8afa-ad9551f82d4d"), MakeId = new Guid("2561ad51-2c14-430f-bc1f-01672bf5630c"), Name = "206 (Peugeot)", Abrv = "206" },
                new VehicleModel { Id = new Guid("c336a949-372c-4b29-b5b9-96220f099275"), MakeId = new Guid("cd798a79-200f-4071-ba1e-4e84e6e01aff"), Name = "6 (Mazda)", Abrv = "6" },
                new VehicleModel { Id = new Guid("4de345e7-a4e5-4f6a-bf87-71bc77c18292"), MakeId = new Guid("cd798a79-200f-4071-ba1e-4e84e6e01aff"), Name = "3 (Mazda)", Abrv = "3" },
                new VehicleModel { Id = new Guid("5e852ab4-3d11-4c58-9dbe-4b695911f0f0"), MakeId = new Guid("d50672a0-e817-4a64-9c89-9208cac982f9"), Name = "RAV4 (Toyota)", Abrv = "RAV4" },
                new VehicleModel { Id = new Guid("46176513-eb86-4585-8c37-e05a802c9fd4"), MakeId = new Guid("d50672a0-e817-4a64-9c89-9208cac982f9"), Name = "Corola (Toyota) ", Abrv = "Corola" },
                new VehicleModel { Id = new Guid("1346b937-cda7-4d9f-824d-bc3fb17659b6"), MakeId = new Guid("d50672a0-e817-4a64-9c89-9208cac982f9"), Name = "Yaris (Toyota)", Abrv = "Yaris" },
                new VehicleModel { Id = new Guid("05d1869c-3ccf-4885-8d13-cd329a309ec9"), MakeId = new Guid("d50672a0-e817-4a64-9c89-9208cac982f9"), Name = "Auris (Toyota)", Abrv = "Auris" },
                new VehicleModel { Id = new Guid("5b5f79f7-ab2f-48ce-a02d-ed622bab9a17"), MakeId = new Guid("2f6446cf-b745-4c95-ac55-afe92487610d"), Name = "CR-V (Honda)", Abrv = "CR-V" },
                new VehicleModel { Id = new Guid("ef68b28b-663b-4604-aca3-8baad3703692"), MakeId = new Guid("2f6446cf-b745-4c95-ac55-afe92487610d"), Name = "Accord (Honda)", Abrv = "Accord" },
                new VehicleModel { Id = new Guid("18d8b8f1-215e-49f9-9ad8-9e1f10aaad3d"), MakeId = new Guid("039fd2e6-e674-4599-9d33-1139823a74f0"), Name = "Swift (Suzuki)", Abrv = "SWIFT" },
                new VehicleModel { Id = new Guid("9c3a8354-bf32-4997-85f4-a5eaf7a66478"), MakeId = new Guid("039fd2e6-e674-4599-9d33-1139823a74f0"), Name = "Ignis (Suzuki) ", Abrv = "Ignis" },
                new VehicleModel { Id = new Guid("67d5ff55-f55e-4daa-818f-e857f5a0a51b"), MakeId = new Guid("039fd2e6-e674-4599-9d33-1139823a74f0"), Name = "Jimny 7 (Suzuki)", Abrv = "Jimny" },
                new VehicleModel { Id = new Guid("ababecc8-e9e0-4b96-9536-a42b7bce4dec"), MakeId = new Guid("22ecc5e7-c688-4f7e-aac3-5595d7334bd8"), Name = "Lancer (Mitsubishi)", Abrv = "Lancer" },
                new VehicleModel { Id = new Guid("847e2f9b-e47b-44ce-bba8-689b25730705"), MakeId = new Guid("22ecc5e7-c688-4f7e-aac3-5595d7334bd8"), Name = "Mirage (Mitsubishi) ", Abrv = "Mirage" },
                new VehicleModel { Id = new Guid("c9186453-b5b9-49e1-9c11-e9675ddb7993"), MakeId = new Guid("061fe685-971d-46e6-b374-a95baa59fcc4"), Name = "G-Class (Mercedes)", Abrv = "G-Class" },
                new VehicleModel { Id = new Guid("dc51aa3b-472e-4a8d-8d53-f14bbcafe65a"), MakeId = new Guid("942e29d9-ab57-4459-9171-200781e9ac57"), Name = "Kona (Kia)", Abrv = "Kona" },
                new VehicleModel { Id = new Guid("88aa7a7d-4762-48f1-b3e0-309b256dd3e6"), MakeId = new Guid("942e29d9-ab57-4459-9171-200781e9ac57"), Name = "Sportage (Kia) ", Abrv = "Sportage" },
                new VehicleModel { Id = new Guid("4c05e868-63f5-4943-9f6a-e34dc90c5315"), MakeId = new Guid("942e29d9-ab57-4459-9171-200781e9ac57"), Name = "Rio (Kia)", Abrv = "Rio" },
                new VehicleModel { Id = new Guid("57c7b7b3-d2e8-4710-a002-7f600d449296"), MakeId = new Guid("a40c6c8e-cff7-4b53-9a92-2bb83ca36cbc"), Name = "Qashqai (Nissan)", Abrv = "Qashqai" },
                new VehicleModel { Id = new Guid("ace5d013-6a3c-4255-b8e6-ec1e68e7b9b1"), MakeId = new Guid("a40c6c8e-cff7-4b53-9a92-2bb83ca36cbc"), Name = "Juke (Nissan)", Abrv = "Juke" },
                new VehicleModel { Id = new Guid("70203419-5052-4f7c-a403-8f3f54736bbb"), MakeId = new Guid("6bcdfb19-6224-49ce-9bdb-6562c0f2586b"), Name = "Concept_One (Rimac)", Abrv = "Concept_One" },
            };
            modelBuilder.Entity<VehicleModel>().HasData(vehicleModels);
        }
    }
}
