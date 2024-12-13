using SWVUEL.Infrastructure.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWVUEL.Infrastructure.Contracts
{
    public interface IRepository
    {
        Task<StarshipApiResponseEntity> GetStarshipFromApiAsync();
        Task<StarshipApiResponseEntity> GetStarshipAsync();
        Task UpsertStarshipAsync(Starship starship);
        Task<List<string>> GetAllStarshipNamesAsync();
        Task<bool> UpdateStarshipNameAsync(int id, string newName);

        Task<Starship> GetStarshipByIdAsync(int id);

        Task<bool> UpdateStarshipNameAndModelAsync(int id, string newName, string newModel);




    }
}
