using Microsoft.AspNetCore.Mvc;
using SWVUEL.Infrastructure.Contracts;
using SWVUEL.Infrastructure.Contracts.Entities;
using SWVUEL.Library.Contracts;
using SWVUEL.Library.Contracts.DTOs;
using SWVUEL.XCutting.Enums;

namespace SWVUEL.Library.Impl
{
    public class Service : IService
    {
        private readonly IRepository _repository;

        public Service(IRepository repository)
        {
            _repository = repository;
        }

        async Task<List<StarshipApiDto>> IService.GetStarshipAsync()
        {
            var apiResponse = await _repository.GetStarshipAsync();

            // Adaptación: Convertir `PlanetDto` a `Planet`
            return apiResponse.results.Select(dto => new StarshipApiDto
            {
                name = dto.name,
                model = dto.model,
                manufacturer = dto.manufacturer,
                cost_in_credits = dto.cost_in_credits,
                length = dto.length,
                crew = dto.crew,
                passengers = dto.passengers,
                starship_class = dto.starship_class,
                url = dto.url
            }).ToList();
        }

        public async Task<List<string>> SyncStarshipAsync()
        {
            var apiResponse = await _repository.GetStarshipFromApiAsync();
            
            if (apiResponse.results != null)
            {
                foreach (var dto in apiResponse.results)
                {
                    var starship = new Starship
                    {
                        name = dto.name,
                        model = dto.model,
                        manufacturer = dto.manufacturer,
                        cost_in_credits = dto.cost_in_credits,
                        length = dto.length,
                        crew = dto.crew,
                        passengers = dto.passengers,
                        starship_class = dto.starship_class,
                        url = dto.url
                    };
                    
                    await _repository.UpsertStarshipAsync(starship);
                }
            }
            // Retorna la lista de nombres de planetas actuales en la base de datos
            return await _repository.GetAllStarshipNamesAsync();
        }

        public async Task<bool> UpdateStarshipNameAsync(int id, string newName)
        {
            return await _repository.UpdateStarshipNameAsync(id, newName);
        }


        public async Task<(string Name, string Model)> GetStarshipNameAndModelByIdAsync(int id)
        {
            // Validación: asegurar que el id sea positivo
            if (id <= 0)
            {
                throw new ArgumentException("El id debe ser un valor positivo", nameof(id));
            }

            // Obtén el starship por id
            var starship = await _repository.GetStarshipByIdAsync(id);

            // Si el starship no existe, devuelve null
            if (starship == null)
            {
                return (null, null);
            }

            // Devuelve solo los campos name y model
            return (starship.name, starship.model);
        }




        public async Task<ErrorCode> UpdateStarshipNameAndModelAsync(int id, string newName, string newModel)
        {
            // Validación: Asegura que el id es positivo
            if (id <= 0)
            {
                return ErrorCode.InvalidId;
            }

            // Validación: Asegura que los nuevos valores no sean nulos o vacíos
            if (string.IsNullOrWhiteSpace(newName))
            {
                return ErrorCode.EmptyOrNullName;
            }

            if (string.IsNullOrWhiteSpace(newModel))
            {
                return ErrorCode.EmptyOrNullModel;
            }

            // Llama al repositorio para actualizar el Starship
            var updated = await _repository.UpdateStarshipNameAndModelAsync(id, newName, newModel);

            // Si no se encontró el Starship
            if (!updated)
            {
                return ErrorCode.StarshipNotFound;
            }

            // Si todo fue bien, devolvemos 0 como código de éxito o puedes crear un código para éxito
            return ErrorCode.UnknownError; // O define un código específico de éxito si prefieres.
        }

    }

}
