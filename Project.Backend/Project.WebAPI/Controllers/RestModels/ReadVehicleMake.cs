﻿using System;

namespace Project.WebAPI.Controllers.RestModels
{
    public class ReadVehicleMake
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
    }
}
