using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Project.Common.Paging;
using Project.Model.Common.VehicleMakeResource;
using Project.Model.Common.VehicleModelResource;
using Project.Model.VehicleMakeResource;
using Project.Model.VehicleModelResource;
using Project.Model.VehicleModelResoure.Params;
using Project.Service.Common;
using Project.WebAPI.Controllers.RestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.WebAPI.Controllers
{
    [Route("api/models")]
    [ApiController]
    public class VehicleModelController : Controller
    {
        public readonly IVehicleModelService service;
        public readonly IMapper mapper;

        public VehicleModelController(IVehicleModelService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<VehicleModel>> CreateModel(IVehicleModel<VehicleMake> modelToCreate)
        {
            ModelState["Id"]?.Errors.Clear();
            ModelState["Make.Id"]?.Errors.Clear();

            if (!ModelState.IsValid) return BadRequest(ModelState);

            var createdVehicleModel = await service.CreateVehicleModel(modelToCreate);

            if (createdVehicleModel == null) return BadRequest("Model already exists.");

            var createdVehicleModelRestModel = mapper.Map<ReadVehicleModel>(createdVehicleModel);

            return Created($"api/makes/{createdVehicleModelRestModel.Id}", createdVehicleModelRestModel);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<VehicleModel>> GetModel(Guid id)
        {
            var vehicleModel = await service.ReadVehicleModel(id);

            if (vehicleModel == null) return NotFound("Vehicle model not found.");

            var vehicleModelRestModel = mapper.Map<ReadVehicleModel>(vehicleModel);

            return Ok(vehicleModelRestModel);
        }

        [HttpGet]
        public async Task<ActionResult<PagedList<VehicleModel>>> GetModels([FromQuery] ReadVehicleModelsParams readParams)
        {
            var vehicleModels = await service.ReadVehicleModels(readParams);

            if (!vehicleModels.Any()) return NotFound("Vehicle model not found.");

            var vehicleModelsRestModel = vehicleModels.ToMappedPagedList<VehicleModel, ReadVehicleModel>(mapper);

            return Ok(vehicleModelsRestModel);
        }

        [HttpPatch("{id:guid}")]
        public async Task<ActionResult<VehicleModel>> UpdateModel(Guid id, 
            [FromBody] JsonPatchDocument<IVehicleModel<VehicleMake>> modelUpdatesPatch)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            else
            {
                try
                {
                    var modelToUpdate = await service.ReadVehicleModel(id);

                    if (modelToUpdate == null) return NotFound("Vehicle model not found.");

                    modelUpdatesPatch.ApplyTo(modelToUpdate);
                    var updatedModel = await service.UpdateVehicleModel(modelToUpdate);
                    var updatedVehicleMakeRestModel = mapper.Map<ReadVehicleModel>(updatedModel);

                    return Ok(updatedVehicleMakeRestModel);
                }
                catch (Exception ex) { return BadRequest(ex); }
            }
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<VehicleModel>> DeleteModel(Guid id)
        {
            var vehicleModelToDelete = await service.DeleteVehicleModel(id);

            if (vehicleModelToDelete == null) return NotFound("Vehicle model not found.");

            var deletedVehicleMakeRestModel = mapper.Map<ReadVehicleModel>(vehicleModelToDelete);

            return Ok(deletedVehicleMakeRestModel);
        }
    }
}
