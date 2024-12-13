using SWVUEL.Library.Contracts.DTOs;
using SWVUEL.XCutting.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWVUEL.Library.Contracts
{
    public interface IService
    {
        Task<List<StarshipApiDto>> GetStarshipAsync();
        Task<List<string>> SyncStarshipAsync();
        Task<bool> UpdateStarshipNameAsync(int id, string newName);

        Task<(string Name, string Model)> GetStarshipNameAndModelByIdAsync(int id);

        Task<ErrorCode> UpdateStarshipNameAndModelAsync(int id, string newName, string newModel);


    }
}
