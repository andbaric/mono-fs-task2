using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Project.Common.Paging;
using Project.Model;
using Project.Model.Common.VehicleMakeResource;
using Project.Model.VehicleMakeResource;
using Project.Model.VehicleMakeResource.Params;
using Project.Service.Common;
using Project.WebAPI.Controllers.RestModels;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Project.WebAPI.Controllers
{
    [Route("api/makes")]
    [ApiController]
    public class VehicleMakeController : Controller
    {
        public readonly IVehicleMakeService service;
        public readonly IMapper mapper;

        public VehicleMakeController(IVehicleMakeService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<ReadVehicleMake>> CreateMake(CreateParams makeToCreateParams)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var makeToCreate = mapper.Map<VehicleMake>(makeToCreateParams);
            var createdVehicleMake = await service.CreateVehicleMake(makeToCreate);
            var createdVehicleMakeRestModel = mapper.Map<ReadVehicleMake>(createdVehicleMake);

            return Created($"api/makes/{createdVehicleMakeRestModel.Id}", createdVehicleMakeRestModel);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ReadVehicleMake>> ReadMake(Guid id)
        {
            var vehicleMake = await service.ReadVehicleMake(id);

            if (vehicleMake == null) return NotFound("Vehicle make not found.");

            var vehicleMakeRestModel = mapper.Map<ReadVehicleMake>(vehicleMake);

            return Ok(vehicleMakeRestModel);
        }

        [HttpGet]
        public async Task<ActionResult<PagedList<VehicleMake>>> ReadMakes([FromQuery] ReadVehicleMakesParams readParams)
        {
            var vehicleMakes = await service.ReadVehicleMakes(readParams);

            if (!vehicleMakes.Any()) return NotFound("Vehicle make not found.");

            var vehicleMakesRestModel = vehicleMakes.ToMappedPagedList<VehicleMake, ReadVehicleMake>(mapper);

            return Ok(vehicleMakesRestModel);
        }

        [HttpPatch("{id:guid}")]
        public async Task<ActionResult<ReadVehicleMake>> UpdateMake(Guid id, [FromBody] JsonPatchDocument<IVehicleMake> makeUpdatesPatch)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            else
            {
                try
                {
                    var makeToUpdate = await service.ReadVehicleMake(id);

                    if (makeToUpdate == null) return NotFound("Vehicle make not found.");

                    makeUpdatesPatch.ApplyTo(makeToUpdate);
                    var updatedMake = await service.UpdateVehicleMake(makeToUpdate);
                    var updatedMakeRestModel = mapper.Map<ReadVehicleMake>(updatedMake);

                    return Ok(updatedMakeRestModel);
                }
                catch (Exception ex) { return BadRequest(ex); }
            }
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<ReadVehicleMake>> DeleteMake(Guid id)
        {
            var deletedVehicleMake = await service.DeleteVehicleMake(id);

            if (deletedVehicleMake == null) return NotFound("Vehicle make not found.");

            var deletedVehicleMakeRestModel = mapper.Map<ReadVehicleMake>(deletedVehicleMake);

            return Ok(deletedVehicleMakeRestModel);
        }
    }
}
