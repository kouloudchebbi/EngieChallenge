using System.Collections.Generic;
using AppData.Interfaces;
using AppData.DataModels;
using AppData.Extensions;

namespace AppData.Services
{
    public class EngieService: IEngieService
    {
        public IEnumerable<PowerOutput> GetProductionPlan(IEnumerable<PowerPlantDto> powerPlants, FuelDto fuel, decimal load)
        { 
            return powerPlants
                .GetPants(fuel)
                .OrderPowerPlants()
                .ReportPlanLoad(load);
        }
    }
}