using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Project.Model.DTOs.VehicleModel;
using Project.Model.DTOs.VehicleModel.ReadVehicleModels;
using Project.Service.Common;
using System;
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
        public async Task<ActionResult<CreateVehicleModelResponse>> CreateModel(CreateVehicleModelRequest request)
        {
            await service.CreateVehicleModel(request);

            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<ReadVehicleModelsResponse>> GetModels()
        {
            var getModelsRequest = new ReadVehicleModelsRequest();
            var getModelsResult = await service.ReadVehicleModels(getModelsRequest);

            return Ok(getModelsResult);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReadVehicleModelResponse>> GetModel(Guid id)
        {
            var getModelRequest = new ReadVehicleModelRequest() { Id = id };
            var getModelResponse = await service.ReadVehicleModel(getModelRequest);

            if (getModelResponse == null) return NotFound();

            return Ok(getModelResponse);
        }

        [HttpPatch("{id:guid}")]
        public async Task<ActionResult<UpdateVehicleModelResponse>> UpdateModel(Guid id, [FromBody] JsonPatchDocument<UpdateVehicleModelRequest> makePatch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                try
                {
                    var getModelRequest = new ReadVehicleModelRequest() { Id = id };
                    var makeToUpdate = await service.ReadVehicleModel(getModelRequest);

                    if (makeToUpdate == null) return NotFound();

                    var makeToUpdateRequest = mapper.Map<UpdateVehicleModelRequest>(makeToUpdate);

                    makePatch.ApplyTo(makeToUpdateRequest);
                    await service.UpdateVehicleModel(makeToUpdateRequest);
                }
                catch (Exception ex) { return BadRequest(ex); }
            }

            return Ok();
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<DeleteVehicleModelResponse>> DeleteModel(Guid id)
        {
            var deleteModelRequest = new DeleteVehicleModelRequest() { Id = id };
            var deleteModelResponse = await service.DeleteVehicleModel(deleteModelRequest);

            if (deleteModelResponse == null) return NotFound();

            return Ok();
        }
    }
}
