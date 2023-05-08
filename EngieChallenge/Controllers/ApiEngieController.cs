using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;
using AppData.Interfaces;
using EngieChallenge.Models;
using Microsoft.AspNetCore.Mvc;

namespace EngieChallenge.Controllers
{

    [System.Web.Mvc.Route("[controller]")]
    public class ApiEngieController : ApiController
    {
        private readonly IEngieService _iPowerPlantService;
   
        
        public ApiEngieController(IEngieService iPowerPlantService)
        {
            _iPowerPlantService = iPowerPlantService;
         
        }

        //Mapping 
        public List<AppData.DataModels.PowerPlantDto> mappingPowerPlantToDTO(List<Models.PowerPlant> Modele)
        {
            List<AppData.DataModels.PowerPlantDto> Dto = new List<AppData.DataModels.PowerPlantDto>();
            foreach (Models.PowerPlant m in Modele)
            {
                Dto.Add(new AppData.DataModels.PowerPlantDto {
                    Name = m.Name,               
                    Efficiency = m.Efficiency,
                    PMin = m.PMin,
                    PMax = m.PMax
                });

            }

            return Dto;
        }

        public AppData.DataModels.FuelDto mappingFuelToDTO(Models.Fuel Modele)
        {
            AppData.DataModels.FuelDto Dto = new AppData.DataModels.FuelDto();

            Dto = new AppData.DataModels.FuelDto
            {
                Co2 = Modele.Co2,
                Gas = Modele.Gas,
                Kerosine = Modele.Kerosine,
                Wind = Modele.Wind

            };

            return Dto;
        }

      

        [System.Web.Mvc.HttpPost]
        public IActionResult Calculate([FromBody] LoadRequest request)
        {
            var mappedPowerPlants= mappingPowerPlantToDTO((List<PowerPlant>)request.PowerPlants);
            AppData.DataModels.FuelDto mappedFuel = mappingFuelToDTO(request.Fuels );
            return (IActionResult)Ok(_iPowerPlantService.GetProductionPlan(mappedPowerPlants, mappedFuel, request.Load));
        }

        //protected override void ExecuteCore()
        //{
        //    throw new System.NotImplementedException();
        //}
    }
}