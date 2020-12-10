using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Project.DAL.Entities;
using Project.Model.DTOs.VehicleMake;
using Project.Model.DTOs.VehicleMake.ReadVehicleMakes;
using Project.Service.Common;
using Project.WebAPI.Filters;
using System;
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
        public async Task<ActionResult<CreateVehicleMakeResponse>> CreateMake(CreateVehicleMakeRequest request)
        {
            await service.CreateVehicleMake(request);

            return Ok();
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ReadVehicleMakeResponse>> GetMake(Guid id)
        {
            var getMakeRequest = new ReadVehicleMakeRequest(){ Id = id };
            var getMakeResponse = await service.ReadVehicleMake(getMakeRequest);

            if (getMakeResponse == null) return NotFound();

            return Ok(getMakeResponse);
        }

        [HttpGet]
        public async Task<ActionResult<ReadVehicleMakesResponse>> GetMakes()
        {
            var getMakesRequest = new ReadVehicleMakesRequest();
            var getMakesResponse = await service.ReadVehicleMakes(getMakesRequest);

            return Ok(getMakesResponse);
        }

        [HttpPatch("{id:guid}")]
        public async Task<ActionResult<UpdateVehicleMakeResponse>> UpdateMake(Guid id, [FromBody] JsonPatchDocument<UpdateVehicleMakeRequest> makePatch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                try
                {
                    var getMakeRequest = new ReadVehicleMakeRequest() { Id = id };
                    var makeToUpdate = await service.ReadVehicleMake(getMakeRequest);

                    if (makeToUpdate == null) return NotFound();

                    var makeToUpdateRequest = mapper.Map<UpdateVehicleMakeRequest>(makeToUpdate);

                    makePatch.ApplyTo(makeToUpdateRequest);
                    await service.UpdateVehicleMake(makeToUpdateRequest);
                }
                catch (Exception ex) { return BadRequest(ex); }
            }

            return Ok();
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<DeleteVehicleMakeResponse>> DeleteMake(Guid id)
        {
            var deleteMakeRequest = new DeleteVehicleMakeRequest() { Id = id };
            var deleteMakeResponse = await service.DeleteVehicleMake(deleteMakeRequest);

            if (deleteMakeResponse == null) return NotFound();

            return Ok();
        }
    }
}
