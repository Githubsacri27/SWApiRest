using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SWVUEL.Library.Contracts;
using SWVUEL.Library.Contracts.DTOs;
using SWVUEL.XCutting.Enums;

namespace SWVUEL.DistributedService.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StarshipController : ControllerBase
    {
        private readonly IService _service;

        public StarshipController(IService service)
        {
            _service = service;
        }



        [HttpGet("GetStarships")]
        public async Task<IActionResult> GetStarships()
        {
            var starships = await _service.GetStarshipAsync();
            return Ok(starships);
        }


        [HttpPost("SyncStarship")]
        public async Task<IActionResult> SyncStarship()
        {
            var starshipNames = await _service.SyncStarshipAsync();
            return Ok(starshipNames);
        }



        [HttpPut("UpdateStarshipNameAndModel")]
        public async Task<IActionResult> UpdateStarshipNameAndModel(int id, [FromBody] UpdateStarshipDto dto)
        {
            try
            {
                // Llama al servicio para actualizar el name y model y recibe un código de error
                var errorCode = await _service.UpdateStarshipNameAndModelAsync(id, dto.NewName, dto.NewModel);

                // Maneja los diferentes códigos de error y devuelve respuestas apropiadas
                return errorCode switch
                {
                    ErrorCode.InvalidId => BadRequest("Invalid ID."),
                    ErrorCode.EmptyOrNullName => BadRequest("Name cannot be empty or null."),
                    ErrorCode.EmptyOrNullModel => BadRequest("Model cannot be empty or null."),
                    ErrorCode.StarshipNotFound => NotFound("Starship not found."),
                    ErrorCode.UnknownError => Ok("Starship updated successfully."),
                    _ => StatusCode(500, "An unexpected error occurred.")
                };
            }
            catch (Exception ex)
            {
                // Manejo general de errores
                return StatusCode(500, "An unexpected error occurred: " + ex.Message);
            }
        }
    





    }
}
