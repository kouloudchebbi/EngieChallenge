using System.Collections.Generic;
using AppData.DataModels;
using AppData.Services;
using NUnit.Framework;


namespace Testing
{
    public class TestCode
    {
        private EngieService _EngieService;
        [SetUp]
        public void SetUp()
        {
            _EngieService = new EngieService();
        }

        [Test]
        public void CalculatingOutput()
        {

            var fuel = new FuelDto()
            {
                Co2 = 20,
                Gas = 13.4M,
                Kerosine = 50.8M,
                Wind = 60,
            };
            const decimal load = 480;
        
            List<PowerPlantDto> powerPlants = new List<PowerPlantDto>();

          
            powerPlants.Add(new PowerPlantDto
            {
                    Name = "gasfiredbig1",
                    Type = PPType.GasFired,
                    Efficiency = 0.53M,
                    PMin = 100,
                    PMax = 460
                });
            powerPlants.Add(new PowerPlantDto
            {
                    Name = "gasfiredbig2",
                    Type = PPType.GasFired,
                    Efficiency = 0.53M,
                    PMin = 100,
                    PMax = 460

                });
            powerPlants.Add(new PowerPlantDto
            {
                    Name = "gasfiredsomewhatsmaller",
                    Type = PPType.GasFired,
                    Efficiency = 0.37M,
                    PMin = 200,
                    PMax = 2100
                });
            powerPlants.Add(new PowerPlantDto
            {
                Name = "tj1",
                Type = PPType.TurboJet,
                Efficiency = 0.3M,
                PMin = 0,
                PMax = 16
            });
            powerPlants.Add(new PowerPlantDto
            {
                Name = "windpark1",
                Type = PPType.WindTurbine,
                Efficiency = 1,
                PMin = 0,
                PMax = 150
            });
            powerPlants.Add(new PowerPlantDto
            {
                Name = "windpark2",
                Type = PPType.WindTurbine,
                Efficiency = 1,
                PMin = 0,
                PMax = 36
            });

            List<PowerOutput> powerOutput = new List<PowerOutput>();
           
            powerOutput.Add(new PowerOutput()
            {

                Name = "gasfiredbig1",
                P = 200
            }
            );
            powerOutput.Add(new PowerOutput()
            {
                Name = "gasfiredbig2",
                P = 0
            }
            );
            powerOutput.Add(new PowerOutput()
            {
                Name = "gasfiredsomewhatsmaller",
                P = 0
            });

            powerOutput.Add(new PowerOutput()
            {
                Name = "windpark1",
                P = 75
            });
            powerOutput.Add(new PowerOutput()
            {
                Name = "windpark2",
                P = 18
            });
            powerOutput.Add(new PowerOutput()
            {
                Name = "tj1",
                P = 0
            });


            var result = _EngieService.GetProductionPlan(powerPlants, fuel, load);
            
            Assert.AreEqual(powerOutput, result);

        }
    }
}