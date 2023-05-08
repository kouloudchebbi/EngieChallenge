using System;
using System.Collections.Generic;
using System.Linq;
using AppData.DataModels;

namespace AppData.Extensions
{
    public static class PowerPlantExtension
    {
        
        public static IEnumerable<PowerPlantDto> GetPants( this IEnumerable<PowerPlantDto> powerPlants,
            FuelDto fuel)
        {
            IList<PowerPlantDto> plants = new List<PowerPlantDto>();
            foreach (var plant in powerPlants)
            {
                plant.PMax = GetPMax(plant, fuel);
              plant.PMin = GetFuelCost(plant, fuel);
                plants.Add(plant);
            }
            return plants;
        }

        private static decimal GetFuelCost(this PowerPlantDto powerPlant, FuelDto fuel)
        {
            if (powerPlant.Type == PPType.WindTurbine)
            {
                return 0.0M;

            }
            if (powerPlant.Type == PPType.GasFired)
            {
                return fuel.Gas;

            }
            else return fuel.Kerosine;
        }

     

        //calculate Pmax for plantif different of WindTurbine
        private static decimal GetPMax(this PowerPlantDto powerPlant, FuelDto fuel)
        {
            if (powerPlant.Type != AppData.DataModels.PPType.WindTurbine)
                return powerPlant.PMax;
            return powerPlant.PMax / 100.0M * fuel.Wind;
        }
        
        public static IEnumerable<PowerPlantDto> OrderPowerPlants (this IEnumerable<PowerPlantDto> powerPlants)
        {
            return powerPlants.OrderByDescending(i => i.Efficiency)  ;
        }
        
        public static IEnumerable<PowerOutput> ReportPlanLoad(this IEnumerable<PowerPlantDto> powerPlants, decimal planLoad)
         {
             var ret = new List<PowerOutput>();
             var load = planLoad;
             powerPlants.ToList().ForEach(p => {
                     if (p.PMin>load)
                     {
                         ret.Add(new PowerOutput()
                         {Name = p.Name, P = 0,
                                });
                         return;
                     }
                     if (load>= p.PMin)
                     {
                         ret.Add(new PowerOutput()
                         {
                             Name = p.Name, 
                             P = Math.Round(load),
                         });
                         load = 0;
                         return;
                     }
                     ret.Add(new PowerOutput()
                     {
                         Name = p.Name,
                         P = Math.Round(load),
                     });
                    
                 });
             return ret;
         }
    }
}