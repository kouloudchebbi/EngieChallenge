using System.Collections.Generic;
using AppData.DataModels;
using AppData.Services;

namespace AppData.Interfaces
{
    public interface IEngieService
    {
         IEnumerable<PowerOutput> GetProductionPlan(IEnumerable<PowerPlantDto> powerPlants, FuelDto fuel, decimal load);
    }
}